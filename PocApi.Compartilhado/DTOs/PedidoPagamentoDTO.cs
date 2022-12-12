using System;

namespace PocApi.Compartilhado.DTOs
{
    public class PedidoPagamentoDTO
    {
        public int IdPedidoPagamento { get; set; }
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public PagamentoDTO PagamentoDTO { get; set; }
        public PedidoDTO PedidoDTO { get; set; }
    }
}