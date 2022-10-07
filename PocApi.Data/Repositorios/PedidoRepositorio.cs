using Entidades;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public PedidoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Pedido> Inserir(Pedido pedido)
        {
            await _appDbContext.Set<Pedido>().AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido;
        }
    }
}
