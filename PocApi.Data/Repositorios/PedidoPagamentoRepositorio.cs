using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class PedidoPagamentoRepositorio : IPedidoPagamentoRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public PedidoPagamentoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PedidoPagamento> Inserir(PedidoPagamento pedidoPagamento)
        {
            await _appDbContext.Set<PedidoPagamento>().AddAsync(pedidoPagamento);
            await _appDbContext.SaveChangesAsync();

            return pedidoPagamento;
        }
        
    }
}
