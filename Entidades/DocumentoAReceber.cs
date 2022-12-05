using Entidades;
using System;
using System.Collections.Generic;

namespace PocApi.Entidades
{
    public class DocumentoAReceber
    {
        public int IdDocumentoAReceber { get; set; }
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataJuros { get; set; }
        public int Carencia { get; set; }
        public decimal Valor { get; set; }
        public decimal Restante { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal ValorPago { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}