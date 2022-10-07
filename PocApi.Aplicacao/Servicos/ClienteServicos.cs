using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class ClienteServicos : IClienteServicos
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IClienteNegocios _clienteNegocios;
        public ClienteServicos(IClienteNegocios clienteNegocios, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _clienteNegocios = clienteNegocios;
        }
        public async Task<RespostaServicoDTO<ClienteDTO>> Alterar(ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();

            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.Alterar(clienteDTO);
                await _unidadeDeTrabalho.CommitAsync();
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteDTO>> Deletar(int idCliente)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();

            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.Deletar(idCliente);
                if (respostaServicoDTO.Dados.IdCliente == 0)
                {
                    respostaServicoDTO.Mensagem = ConstantesMensagens.NenhumRegistroLocalizado;
                }
                await _unidadeDeTrabalho.CommitAsync();
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteDTO>> Inserir(ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();
            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.Inserir(clienteDTO);
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

        public async Task<RespostaServicoDTO<List<ClienteDTO>>> Listar(ClienteFiltroDTO clienteDTO)
        {
            RespostaServicoDTO<List<ClienteDTO>> respostaServicoDTO = new RespostaServicoDTO<List<ClienteDTO>>();
            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.Listar(clienteDTO);

            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteDTO>> ObterPorCodigo(int idCliente)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = new RespostaServicoDTO<ClienteDTO>();

            try
            {
                respostaServicoDTO.Dados = await _clienteNegocios.ObterPorCodigo(idCliente);
                if (respostaServicoDTO.Dados.IdCliente == 0)
                {
                    respostaServicoDTO.Mensagem = ConstantesMensagens.NenhumRegistroLocalizado;
                }
                await _unidadeDeTrabalho.CommitAsync();
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
                
            }
            return respostaServicoDTO;
        }
    }
}
