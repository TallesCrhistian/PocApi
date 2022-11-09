using Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IItemPedidoRepositorio
    {
        Task<ItemPedido> Inserir(ItemPedido itemPedido);
    }
}
