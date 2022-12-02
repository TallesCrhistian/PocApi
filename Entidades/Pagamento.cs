using System.Collections.Generic;

namespace PocApi.Entidades
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public bool? Ativo { get; set; }
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
        public virtual List<DocumentoAReceber> DocumentoAReceber { get; set; }
        public virtual List<PedidoPagamento> PedidosPagamento { get; set; }
    }
}