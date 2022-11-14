using Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocApi.Entidades
{
    public class DocumentoAReceber
    {
        [Key]
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
        [ForeignKey(nameof(IdCliente))]
        public Cliente Cliente { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        [ForeignKey(nameof(IdPagamento))]
        public Pagamento Pagamentos { get; set; }
    }
}
