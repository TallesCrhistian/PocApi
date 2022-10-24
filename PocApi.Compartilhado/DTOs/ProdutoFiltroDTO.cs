namespace PocApi.Compartilhado.DTOs
{
    public class ProdutoFiltroDTO
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool Ativo { get; set; }
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }
    }
}
