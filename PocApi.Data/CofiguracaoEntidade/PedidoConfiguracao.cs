using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class EntidadeConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdPedido);
            entityTypeBuilder.HasOne(x => x.Cliente);
        }
    }
}
