using System;

namespace PocApi.Compartilhado.DTOs
{
    public class DocumentoAReceberDTO
    {
        public int IdDocumentoAReceber { get; set; }
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
        public ClienteDTO ClienteDTO { get; set; }
        public PedidoDTO PedidoDTO { get; set; }
        public PagamentoDTO PagamentoDTO { get; set; }
    }
}
