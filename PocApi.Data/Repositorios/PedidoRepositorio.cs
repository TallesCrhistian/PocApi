using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Enumeradores;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Pedido> Alterar(Pedido pedido)
        {
            pedido.Status = PedidoStatusEnum.Fechado;
            _appDbContext.Set<Pedido>().Update(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> Deletar(int codigo)
        {
            Pedido pedido = await _appDbContext.Pedidos.Where(x => x.IdPedido == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            pedido.Status = PedidoStatusEnum.Cancelado;
            _appDbContext.Set<Pedido>().Update(pedido);

            if (pedido != null) await _appDbContext.SaveChangesAsync();


            return pedido;
        }

        public async Task<Pedido> Inserir(Pedido pedido)
        {
            await _appDbContext.Set<Pedido>().AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<List<Pedido>> Listar(PedidoFiltroDTO pedidoFiltroDTO)
        {
            IQueryable<Pedido> pedidos = _appDbContext.Pedidos
                .Include(x => x.Cliente)
               .Where(x => pedidoFiltroDTO.IdPedido != 0 ? x.IdPedido == pedidoFiltroDTO.IdPedido : true);

            List<Pedido> pedido = await pedidos
                .AsNoTracking()
                .ToListAsync();
            return pedido;
        }

        public async Task<Pedido> ObterPorCodigo(int codigo)
        {
            Pedido pedido = await _appDbContext.Pedidos.Where(x => x.IdPedido == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (pedido != null) await _appDbContext.SaveChangesAsync();


            return pedido;
        }
    }
}
