using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
