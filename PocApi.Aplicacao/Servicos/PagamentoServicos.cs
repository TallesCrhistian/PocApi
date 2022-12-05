using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class PagamentoServicos : IPagamentoServicos
    {
        private readonly IPagamentoNegocios _pagamentoNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IDocumentoAReceberNegocios _documentoAReceberNegocios;

        public PagamentoServicos(IPagamentoNegocios pagamentoNegocios, IUnidadeDeTrabalho unidadeDeTrabalho, IDocumentoAReceberNegocios documentoAReceberNegocios)
        {
            _pagamentoNegocios = pagamentoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _documentoAReceberNegocios = documentoAReceberNegocios;
        }

        public async Task<RespostaServicoDTO<PagamentoDTO>> Alterar(PagamentoDTO pagamentoDTO)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = new RespostaServicoDTO<PagamentoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _pagamentoNegocios.Alterar(pagamentoDTO);
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

        public async Task<RespostaServicoDTO<PagamentoDTO>> Deletar(int codigo)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = new RespostaServicoDTO<PagamentoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _pagamentoNegocios.Deletar(codigo);
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

        public async Task<RespostaServicoDTO<PagamentoDTO>> Inserir(PagamentoDTO pagamentoDTO)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = new RespostaServicoDTO<PagamentoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _pagamentoNegocios.Inserir(pagamentoDTO);
                await _documentoAReceberNegocios.Inserir(pagamentoDTO);
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

        public async Task<RespostaServicoDTO<List<PagamentoDTO>>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO)
        {
            RespostaServicoDTO<List<PagamentoDTO>> respostaServicoDTO = new RespostaServicoDTO<List<PagamentoDTO>>();
            try
            {
                respostaServicoDTO.Dados = await _pagamentoNegocios.Listar(pagamentoFiltroDTO);
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
            }
            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<PagamentoDTO>> ObterPorCodigo(int codigo)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = new RespostaServicoDTO<PagamentoDTO>();
            try
            {
                respostaServicoDTO.Dados = await _pagamentoNegocios.ObterPorCodigo(codigo);
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