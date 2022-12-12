using PocApi.Compartilhado.ModeloDeVisualizacao.Pagamento;
using PocApi.Compartilhado.ModeloDeVisualizacao.Pedido;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoPagamentoViewModel
    {
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public virtual PedidoViewModel PedidoViewModel { get; set; }
        public virtual PagamentoViewModel PagamentoViewModel { get; set; }
    }
}