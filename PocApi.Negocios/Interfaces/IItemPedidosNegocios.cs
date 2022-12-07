using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IItemPedidosNegocios
    {
        Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO);
    }
}