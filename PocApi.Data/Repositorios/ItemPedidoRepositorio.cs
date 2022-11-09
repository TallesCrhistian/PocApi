using Entidades;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System;
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
        public async Task<ItemPedido> Inserir(ItemPedido itemPedido)
        {   
            
            await _appDbContext.Set<ItemPedido>().AddAsync(itemPedido);
            await _appDbContext.SaveChangesAsync();

            return itemPedido;
        }
    }
}
