using Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocApi.Entidades
{
    public class PedidoPagamento
    {
        [Key]
        public int? IdPedidoPagamento { get; set; }
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        [ForeignKey(nameof(IdPagamento))]
        public Pagamento Pagamento { get; set; }
    }
}
