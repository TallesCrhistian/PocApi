using PocApi.Compartilhado.Enumeradores;
using PocApi.Entidades;
using System;
using System.Collections.Generic;
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
        public virtual List<ItemPedido> ItensPedido { get; set; }        
        public virtual List<PedidoPagamento> PedidosPagamento { get; set; }
    }
}
