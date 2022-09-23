using PocApi.Compartilhado.DTOs;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class ClienteServicos : IClienteServicos
    {
        private IClienteNegocios _clienteNegocios;
        public ClienteServicos(IClienteNegocios clienteNegocios)
        {
            _clienteNegocios = clienteNegocios;
        }
        public async Task<RespostaServicoDTO<ClienteDTO>> Alterar(ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();
            try
            {

            }
            catch(Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteDTO>> Inserir(ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();
            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.Inserir(clienteDTO);
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<List<ClienteDTO>>> Listar(ClienteFiltroDTO clienteDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RespostaServicoDTO<ClienteDTO>> ObterPorCodigo(int codigo)
        {
            throw new System.NotImplementedException();
        }
    }
}
