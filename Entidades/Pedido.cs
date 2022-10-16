using PocApi.Compartilhado.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal Frete { get; set; }
        public PedidoStatusEnum Status { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente Cliente { get; set; }
    }
}
