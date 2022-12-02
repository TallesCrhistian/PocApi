using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPedido);
            entityTypeBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.IdCliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.HasMany(x => x.ItensPedido)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.IdItemPedido)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.Property(x => x.ValorProdutos).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.ValorDesconto).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.Frete).HasColumnType("decimal(18,3)");
        }
    }
}