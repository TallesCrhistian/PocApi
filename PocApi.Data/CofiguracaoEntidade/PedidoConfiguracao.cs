using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPedido);
            entityTypeBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.Cliente.IdCliente)
                .IsRequired();
            entityTypeBuilder.HasOne(x => x.DocumentoAReceber)
                .WithOne(x => x.Pedido)
                .HasForeignKey<DocumentoAReceber>(x => x.IdPedido);
        }
    }
}
