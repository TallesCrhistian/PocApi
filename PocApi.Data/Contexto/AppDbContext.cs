using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Entidades;

namespace PocApi.Data.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<PedidoPagamento> PedidosPagamento { get; set; }
        public DbSet<DocumentoAReceber> DocumentoAReceber { get; set; }
    }
}
