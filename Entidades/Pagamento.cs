using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocApi.Entidades
{
    public class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }        
        public bool? Ativo { get; set; } 
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
        public virtual List<PedidoPagamento> PedidosPagamento { get; set; }

    }
}
