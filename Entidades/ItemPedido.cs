using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ItemPedido
    {
        [Key]

        public int IdItemPedido { get; set; }
        public int Ordem { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public virtual Pedido Pedido  { get; set; }
        [ForeignKey(nameof(IdProduto))]
        public virtual Produto Produto { get; set; }
    }
}
