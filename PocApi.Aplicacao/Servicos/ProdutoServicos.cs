using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class ProdutoServicos : IProdutoServicos
    {
        private readonly IProdrutoNegocios _prodrutoNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IItemPedidosNegocios _itemPedidosNegocios;

        public ProdutoServicos(IProdrutoNegocios prodrutoNegocios, IUnidadeDeTrabalho unidadeDeTrabalho, IItemPedidosNegocios itemPedidosNegocios)
        {
            _prodrutoNegocios = prodrutoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _itemPedidosNegocios = itemPedidosNegocios;
        }

        public async Task<RespostaServicoDTO<ProdutoDTO>> Alterar(ProdutoDTO produtoDTO)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = new RespostaServicoDTO<ProdutoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _prodrutoNegocios.Alterar(produtoDTO);
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

        public async Task<RespostaServicoDTO<ProdutoDTO>> Deletar(int codigo)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = new RespostaServicoDTO<ProdutoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _prodrutoNegocios.Deletar(codigo);
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

        public async Task<RespostaServicoDTO<ProdutoDTO>> Inserir(ProdutoDTO produtoDTO)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = new RespostaServicoDTO<ProdutoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _prodrutoNegocios.Inserir(produtoDTO);
                respostaServicoDTO.Dados = await _itemPedidosNegocios.Inserir(produtoDTO);
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

        public async Task<RespostaServicoDTO<List<ProdutoDTO>>> Listar(ProdutoFiltroDTO produtoFiltroDTO)
        {
            RespostaServicoDTO<List<ProdutoDTO>> respostaServicoDTO = new RespostaServicoDTO<List<ProdutoDTO>>();
            try
            {
                respostaServicoDTO.Dados = await _prodrutoNegocios.Listar(produtoFiltroDTO);
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

        public async Task<RespostaServicoDTO<ProdutoDTO>> ObterPorCodigo(int codigo)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = new RespostaServicoDTO<ProdutoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _prodrutoNegocios.ObterPorCodigo(codigo);
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