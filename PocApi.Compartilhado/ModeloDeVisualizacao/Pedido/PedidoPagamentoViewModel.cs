using PocApi.Compartilhado.ModeloDeVisualizacao.Pagamento;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoPagamentoViewModel
    {
        public int IdPagamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public PagamentoViewModel PagamentoViewModel { get; set; }
    }
}