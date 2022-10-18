using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using PocApi.Utils.Utils;
using System;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class UsuarioServicos : IUsuarioServicos
    {
        private readonly IUsuarioNegocios _usuarioNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public UsuarioServicos(IUsuarioNegocios usuarioNegocios, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _usuarioNegocios = usuarioNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task<RespostaServicoDTO<UsuarioDTO>> Login(UsuarioDTO usuarioDTO)
        {
            RespostaServicoDTO<UsuarioDTO> respostaServicoDTO = new RespostaServicoDTO<UsuarioDTO>();
            try
            {
                UsuarioDTO usuarioDTOBanco = await _usuarioNegocios.ObterPorEmail(usuarioDTO.Email);
                if (usuarioDTOBanco.IdUsuario == 0)
                {
                    respostaServicoDTO.Sucesso = false;
                    respostaServicoDTO.Mensagem = ConstantesMensagens.NenhumRegistroLocalizado;
                    return respostaServicoDTO;
                }
                
                else if (!SenhaHashUtil.VerificarSenhaHash(usuarioDTO.Senha, usuarioDTOBanco.SenhaHash, usuarioDTOBanco.SenhaSalt))
                {
                    respostaServicoDTO.Sucesso = false;
                    respostaServicoDTO.Mensagem = ConstantesMensagens.SenhaInvalida;
                    return respostaServicoDTO;
                }

                respostaServicoDTO.Mensagem = "Login efetuado com sucesso";

            }

            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<UsuarioDTO>> Registrar(UsuarioDTO usuarioDTO)
        {
            RespostaServicoDTO<UsuarioDTO> respostaServicoDTO = new RespostaServicoDTO<UsuarioDTO>();
            try
            {
                UsuarioDTO usuarioDTOBanco = await _usuarioNegocios.ObterPorEmail(usuarioDTO.Email);
                if (usuarioDTOBanco.IdUsuario == 0)
                {
                    SenhaHashUtil.CriarSenhaHash(usuarioDTO.Senha, out byte[] _senhaHash, out byte[] _senhaSalt);
                    usuarioDTO.SenhaHash = _senhaHash;
                    usuarioDTO.SenhaSalt = _senhaSalt;

                    respostaServicoDTO.Dados = await _usuarioNegocios.Inserir(usuarioDTO);
                }
                else
                {
                    respostaServicoDTO.Sucesso = false;
                    respostaServicoDTO.Mensagem = ConstantesMensagens.EmailJaExiste(usuarioDTO.Email);
                }
                await _unidadeDeTrabalho.CommitAsync();
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;
        }
    }
}
