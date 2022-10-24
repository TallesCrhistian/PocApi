using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class PedidoServicos : IPedidoServicos
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IPedidoNegocios _pedidoNegocios;
        
        public PedidoServicos(IUnidadeDeTrabalho unidadeDeTrabalho, IPedidoNegocios pedidoNegocios, IClienteNegocios clienteNegocios)
        {            
            _pedidoNegocios = pedidoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<RespostaServicoDTO<PedidoDTO>> Inserir(PedidoDTO pedidoDTO)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();
            try
            {
                
                respostaServicoDTO.Dados = await _pedidoNegocios.Inserir(pedidoDTO);
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

        public async Task<RespostaServicoDTO<List<PedidoDTO>>> Listar(PedidoFiltroDTO pedidoFiltroDTO)
        {
            RespostaServicoDTO<List<PedidoDTO>> respostaServicoDTO = new RespostaServicoDTO<List<PedidoDTO>>();
            try
            {

                respostaServicoDTO.Dados = await _pedidoNegocios.Listar(pedidoFiltroDTO);

            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<PedidoDTO>> ObterPorCodigo(int codigo)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();

            try
            {
                respostaServicoDTO.Dados = await _pedidoNegocios.ObterPorCodigo(codigo);
                if (respostaServicoDTO.Dados.IdPedido == 0)
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

        public async Task<RespostaServicoDTO<PedidoDTO>> Alterar(PedidoDTO pedidoDTO)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();

            try
            {
                pedidoDTO = await _pedidoNegocios.ObterPorCodigo(pedidoDTO.IdPedido);
                respostaServicoDTO.Dados = await _pedidoNegocios.Alterar(pedidoDTO);
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

        public async Task<RespostaServicoDTO<PedidoDTO>> Deletar(PedidoDTO pedidoDTO)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();

            try
            {
                pedidoDTO = await _pedidoNegocios.ObterPorCodigo(pedidoDTO.IdPedido);
                respostaServicoDTO.Dados = await _pedidoNegocios.Deletar(pedidoDTO);
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
    }
}
