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
    }
}
