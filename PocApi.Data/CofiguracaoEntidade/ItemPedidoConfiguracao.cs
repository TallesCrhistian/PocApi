﻿using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PocApi.Data.CofiguracaoEntidade
{
    public class ItemPedidoConfiguracao : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.IdItemPedido);

            entityTypeBuilder.Property(x => x.PrecoCusto).HasColumnType("decimal(18,3)");
            entityTypeBuilder.Property(x => x.PrecoVenda).HasColumnType("decimal(18,3)");
        }
    }
}