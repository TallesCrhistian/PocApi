using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IPedidoNegocios
    {
        Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO);
    }
}
