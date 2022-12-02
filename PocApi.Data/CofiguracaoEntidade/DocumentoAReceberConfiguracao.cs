using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class DocumentoAReceberConfiguracao : IEntityTypeConfiguration<DocumentoAReceber>
    {
        public void Configure(EntityTypeBuilder<DocumentoAReceber> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdDocumentoAReceber);
            entityTypeBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.DocumentoAReceber)
                .HasForeignKey(x => x.IdCliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.HasOne(x => x.Pagamento)
                .WithMany(x => x.DocumentoAReceber)
                .HasForeignKey(x => x.IdPagamento)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.HasOne(x => x.Pedido)
                .WithMany(x => x.DocumentoAReceber)
                .HasForeignKey(x => x.IdPedido)
                .OnDelete(DeleteBehavior.NoAction);

            entityTypeBuilder.Property(x => x.Valor).HasPrecision(18, 3);
            entityTypeBuilder.Property(x => x.ValorPago).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.Restante).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.PercentualJuros).HasColumnType("decimal(18,3)");
        }
    }
}