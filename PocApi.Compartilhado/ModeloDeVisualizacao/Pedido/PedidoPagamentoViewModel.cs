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
    }
}
