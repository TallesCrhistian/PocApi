using Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocApi.Entidades
{
    public class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }
        public int IdDocumentoAReceber  { get; set; }
        public bool? Ativo { get; set; } 
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
        [ForeignKey(nameof(IdDocumentoAReceber))]
        public virtual DocumentoAReceber DocumentoAReceber { get; set; }        
        public virtual List<PedidoPagamento> PedidosPagamento { get; set; }

    }
}
