using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IPedidoPagamentoRepositorio
    {
        Task<PedidoPagamento> Inserir(PedidoPagamento pedidoPagamento);
    }
}
