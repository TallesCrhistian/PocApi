using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class PagamentoConfiguracao : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPagamento);
            entityTypeBuilder.Property(x => x.DiaJuros).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.MultaAtraso).HasColumnType("decimal(18,3)");
        }
    }
}