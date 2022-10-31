using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    interface IPedidoPagamentoNegocios
    {
        Task<PedidoPagamentoDTO> Inserir(PedidoPagamentoDTO pedidoPagamentoDTO);
    }
}
