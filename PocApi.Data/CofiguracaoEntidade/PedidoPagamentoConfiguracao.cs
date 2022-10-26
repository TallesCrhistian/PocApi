using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class PedidoPagamentoConfiguracao : IEntityTypeConfiguration<PedidoPagamento>
    {
        public void Configure(EntityTypeBuilder<PedidoPagamento> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(pp => new { pp.IdPedido, pp.IdPagamento });

            entityTypeBuilder
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidosPagamento)
                .HasForeignKey(pp => pp.IdPagamento);


            entityTypeBuilder
                .HasOne(pp => pp.Pagamento)
                .WithMany(pa => pa.PedidosPagamento)
                .HasForeignKey(pp => pp.IdPedido);

        }
    }
}
