using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<Pagamento> Inserir(Pagamento pagamento);
    }
}
