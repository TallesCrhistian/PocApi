using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class PedidoPagamentoConfiguracao : IEntityTypeConfiguration<PedidoPagamento>
    {
        public void Configure(EntityTypeBuilder<PedidoPagamento> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPedidoPagamento);
            entityTypeBuilder
                .HasOne(x => x.Pedido)
                .WithMany(x => x.PedidosPagamento)
                .HasForeignKey(x => x.IdPagamento)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder
                .HasOne(x => x.Pagamento)
                .WithMany(x => x.PedidosPagamento)
                .HasForeignKey(x => x.IdPedido)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.Property(x => x.Valor).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.Desconto).HasColumnType("decimal(18,3)");
        }
    }
}