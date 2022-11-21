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
            entityTypeBuilder.HasOne(x => x.DocumentoAReceber)
                .WithOne(x => x.Pagamentos);               
                
        }
    }
}
