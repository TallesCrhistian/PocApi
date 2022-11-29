﻿using Microsoft.EntityFrameworkCore;
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
                .WithOne(x => x.DocumentoAReceber)
                .HasForeignKey<DocumentoAReceber>(x => x.IdDocumentoAReceber);

            entityTypeBuilder.HasOne(x => x.Pagamentos)
                .WithOne(x => x.DocumentoAReceber);

            entityTypeBuilder.HasOne(x => x.Pedido)
                .WithOne(x => x.DocumentoAReceber);               

        }
    }
}