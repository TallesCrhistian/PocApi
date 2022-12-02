namespace Entidades
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public bool? Ativo { get; set; } = true;
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}