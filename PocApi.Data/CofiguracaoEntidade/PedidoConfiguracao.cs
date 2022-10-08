using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PocApi.Data.CofiguracaoEntidade
{
    public class EntidadeConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPedido);
            entityTypeBuilder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.Cliente.IdCliente);
        }
    }
}
