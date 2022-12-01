using System.Collections.Generic;

namespace PocApi.Compartilhado.DTOs
{
    public class PagamentoDTO
    {
        public int IdPagamento { get; set; }
        public bool? Ativo { get; set; } = true;
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
        public virtual PedidoDTO PedidoDTO { get; set; }
        public virtual List<PedidoPagamentoDTO> PedidoPagamentoDTO { get; set; }
    }
}
