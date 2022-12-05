using PocApi.Compartilhado.Enumeradores;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao.Pedido
{
    public class PedidoViewModel
    {
        public DateTime Data { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal Frete { get; set; }
        public PedidoStatusEnum Status { get; set; }
        public ClienteViewModel ClienteViewModel { get; set; }
        public ItemPedidoViewModel ItemPedidoViewModel { get; set; }
    }
}