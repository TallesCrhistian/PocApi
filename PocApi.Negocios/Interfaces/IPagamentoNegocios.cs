using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IPagamentoNegocios
    {
        Task<PagamentoDTO> Inserir(PagamentoDTO pagamentoDTO);
        Task<PagamentoDTO> ObterPorCodigo(int codigo);
        Task<List<PagamentoDTO>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO);
        Task<PagamentoDTO> Deletar(int codigo);
        Task<PagamentoDTO> Alterar(PagamentoDTO pagamentoDTO);
    }
}
