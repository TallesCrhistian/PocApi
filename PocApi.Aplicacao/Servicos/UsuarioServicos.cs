using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using PocApi.Utils.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class UsuarioServicos : IUsuarioServicos
    {
        private readonly IUsuarioNegocios _usuarioNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IConfiguration _configuration;

        public UsuarioServicos(IUsuarioNegocios usuarioNegocios, IUnidadeDeTrabalho unidadeDeTrabalho, IConfiguration configuration)
        {
            _usuarioNegocios = usuarioNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _configuration = configuration;
        }

        public async Task<RespostaServicoDTO<string>> Login(UsuarioDTO usuarioDTO)
        {
            RespostaServicoDTO<string> respostaServicoDTO = new RespostaServicoDTO<string>();
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

                string token = CriarToken(usuarioDTOBanco);

                respostaServicoDTO.Dados = token;
            }

            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;
        }

        public  string CriarToken(UsuarioDTO usuarioDTO)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuarioDTO.Email)
            };

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
           
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signingCredentials
            };
            
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();           
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
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
