using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IPedidoPagamentoNegocios
    {
        Task<PedidoPagamentoDTO> Inserir(PedidoPagamentoDTO pedidoPagamentoDTO);
    }
}
