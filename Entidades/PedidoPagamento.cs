using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

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
        public Pedido Pedido { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
