namespace PocApi.Compartilhado.DTOs
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool Ativo { get; set; }
    }
}