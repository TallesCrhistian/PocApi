using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
