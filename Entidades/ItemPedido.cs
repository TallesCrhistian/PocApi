using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class ItemPedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int Ordem { get; set; }
        public int IdProduto { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
