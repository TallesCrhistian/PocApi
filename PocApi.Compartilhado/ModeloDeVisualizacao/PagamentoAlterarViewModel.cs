namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PagamentoAlterarViewModel
    {
        public int IdPagamento { get; set; }
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
    }
}
