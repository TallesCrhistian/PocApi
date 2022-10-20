using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class ProdutoServicos : IProdutoServicos
    {
        private readonly IProdrutoNegocios _prodrutoNegocios;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public ProdutoServicos(IProdrutoNegocios prodrutoNegocios, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _prodrutoNegocios = prodrutoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<RespostaServicoDTO<ProdutoDTO>> Inserir(ProdutoDTO produtoDTO)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = new RespostaServicoDTO<ProdutoDTO>();
            try
            {

                respostaServicoDTO.Dados = await _prodrutoNegocios.Inserir(produtoDTO);
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
