﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocApi.Data.Contexto;

namespace PocApi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Entidades.ItemPedido", b =>
                {
                    b.Property<int>("IdItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<int>("PedidoIdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoCusto")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("IdItemPedido");

                    b.HasIndex("PedidoIdPedido");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("Entidades.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Frete")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("ValorProdutos")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Entidades.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoCusto")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SenhaHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SenhaSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PocApi.Entidades.DocumentoAReceber", b =>
                {
                    b.Property<int>("IdDocumentoAReceber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Carencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataJuros")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("PercentualJuros")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("QuantidadeParcela")
                        .HasColumnType("int");

                    b.Property<decimal>("Restante")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("IdDocumentoAReceber");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPagamento");

                    b.HasIndex("IdPedido");

                    b.ToTable("DocumentoAReceber");
                });

            modelBuilder.Entity("PocApi.Entidades.Pagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiaJuros")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("DiasCarencia")
                        .HasColumnType("int");

                    b.Property<int>("DiasPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("MultaAtraso")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("Parcelas")
                        .HasColumnType("int");

                    b.HasKey("IdPagamento");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("PocApi.Entidades.PedidoPagamento", b =>
                {
                    b.Property<int>("IdPedidoPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("IdPedidoPagamento");

                    b.HasIndex("IdPagamento");

                    b.HasIndex("IdPedido");

                    b.ToTable("PedidosPagamento");
                });

            modelBuilder.Entity("Entidades.ItemPedido", b =>
                {
                    b.HasOne("Entidades.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoIdPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Entidades.Pedido", b =>
                {
                    b.HasOne("Entidades.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PocApi.Entidades.DocumentoAReceber", b =>
                {
                    b.HasOne("Entidades.Cliente", "Cliente")
                        .WithMany("DocumentoAReceber")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PocApi.Entidades.Pagamento", "Pagamento")
                        .WithMany("DocumentoAReceber")
                        .HasForeignKey("IdPagamento")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entidades.Pedido", "Pedido")
                        .WithMany("DocumentoAReceber")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Pagamento");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("PocApi.Entidades.PedidoPagamento", b =>
                {
                    b.HasOne("Entidades.Pedido", "Pedido")
                        .WithMany("PedidosPagamento")
                        .HasForeignKey("IdPagamento")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PocApi.Entidades.Pagamento", "Pagamento")
                        .WithMany("PedidosPagamento")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pagamento");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.Navigation("DocumentoAReceber");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entidades.Pedido", b =>
                {
                    b.Navigation("DocumentoAReceber");

                    b.Navigation("ItensPedido");

                    b.Navigation("PedidosPagamento");
                });

            modelBuilder.Entity("PocApi.Entidades.Pagamento", b =>
                {
                    b.Navigation("DocumentoAReceber");

                    b.Navigation("PedidosPagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
