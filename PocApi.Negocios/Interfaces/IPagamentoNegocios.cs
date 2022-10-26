using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IPagamentoNegocios
    {
        Task<PagamentoDTO> Inserir(PagamentoDTO pagamentoDTO);
        Task<PagamentoDTO> ObterPorCodigo(int codigo);
    }
}
