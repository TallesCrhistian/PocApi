using Entidades;
using System;

namespace PocApi.Entidades
{
    public class PedidoPagamento
    {
        public int IdPedidoPagamento { get; set; }
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}