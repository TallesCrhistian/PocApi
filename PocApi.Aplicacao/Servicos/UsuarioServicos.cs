using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
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

        public async Task<RespostaServicoDTO<UsuarioDTO>> Iserir(UsuarioDTO usuarioDTO)
        {
            RespostaServicoDTO<UsuarioDTO> respostaServicoDTO = new RespostaServicoDTO<UsuarioDTO>();
            try
            {
                respostaServicoDTO.Dados = await _usuarioNegocios.Inserir(usuarioDTO);
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
