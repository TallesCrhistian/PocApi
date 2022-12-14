using PocApi.Compartilhado.Enumeradores;

namespace PocApi.Compartilhado.ModeloDeVisualizacao.Pagamento
{
    public class PagamentoViewModel
    {
        public int IdPagamento { get; set; }
        public PagamentoFormaEnum PagamentoForma { get; set; }
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
    }
}