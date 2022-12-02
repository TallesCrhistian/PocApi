using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdProduto);
            entityTypeBuilder.Property(x => x.PrecoCusto).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.PrecoVenda).HasColumnType("decimal(18,3)");
        }
    }
}