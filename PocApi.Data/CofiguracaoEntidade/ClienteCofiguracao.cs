using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocApi.Entidades;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class ClienteCofiguracao : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdCliente);
            entityTypeBuilder.HasMany(x => x.Pedidos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.IdCliente);

            entityTypeBuilder.HasOne(x => x.DocumentoAReceber)
               .WithOne(x => x.Cliente)
               .HasForeignKey<DocumentoAReceber>(x => x.IdDocumentoAReceber);
        }
    }
}
