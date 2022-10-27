using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IPagamentoServicos
    {
        Task<RespostaServicoDTO<PagamentoDTO>> Inserir(PagamentoDTO pagamentoDTO);
        Task<RespostaServicoDTO<PagamentoDTO>> ObterPorCodigo(int codigo);        
        Task<RespostaServicoDTO<List<PagamentoDTO>>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO);
        Task<RespostaServicoDTO<PagamentoDTO>> Deletar(int codigo);
        Task<RespostaServicoDTO<PagamentoDTO>> Alterar(PagamentoDTO pagamentoDTO);
    }
}
