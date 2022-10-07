using Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<Pedido> Inserir(Pedido pedido);
    }
}
