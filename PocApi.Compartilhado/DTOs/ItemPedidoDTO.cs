namespace PocApi.Compartilhado.DTOs
{
    public class ItemPedidoDTO
    {
        public int IdPedido { get; set; }       
        public int Ordem { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public PedidoDTO PedidoDTO { get; set; }
    }
}