namespace Entidades
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int Ordem { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}