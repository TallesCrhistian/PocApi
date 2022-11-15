using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao.DocumetoAReceber
{
    public class DocumentoAReceberInserirViewModel
    {
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataJuros { get; set; }
        public int Carencia { get; set; }
        public decimal Valor { get; set; }
        public decimal Restante { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal ValorPago { get; set; }
        public ClienteViewModel ClienteDTO { get; set; }
        public PedidoInserirViewModel PedidoDTO { get; set; }
        public PagamentoInserirViewModel PagamentoDTO { get; set; }
    }
}
