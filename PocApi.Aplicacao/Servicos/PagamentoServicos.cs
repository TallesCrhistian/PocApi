using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class PagamentoServicos : IPagamentoServicos
    {
        private readonly IPagamentoNegocios _pagamentoNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public PagamentoServicos(IPagamentoNegocios pagamentoNegocios, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _pagamentoNegocios = pagamentoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task<RespostaServicoDTO<PagamentoDTO>> Inserir(PagamentoDTO pagamentoDTO)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = new RespostaServicoDTO<PagamentoDTO>();
            try
            {

                respostaServicoDTO.Dados = await _pagamentoNegocios.Inserir(pagamentoDTO);
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
