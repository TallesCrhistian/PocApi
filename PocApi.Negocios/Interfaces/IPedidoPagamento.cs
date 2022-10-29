using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    interface IProdutoPagamento
    {
        Task<PedidoPagamento > Inserir { get; set; }
    }
}
