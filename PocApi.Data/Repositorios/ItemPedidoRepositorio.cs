using Entidades;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class ItemPedidoRepositorio : IItemPedidoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ItemPedidoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}