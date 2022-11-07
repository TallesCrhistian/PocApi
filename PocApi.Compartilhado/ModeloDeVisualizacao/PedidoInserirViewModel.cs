using PocApi.Compartilhado.Enumeradores;
using System;
using System.Collections.Generic;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoInserirViewModel
    {
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal Frete { get; set; }
        public PedidoStatusEnum Status { get; set; }
        public List<PedidoPagamentoViewModel> PedidoPagamentoViewModels { get; set; }
        public List<ItemPedidoViewModel> ItemPedidoViewModels { get; set; }
    }
}
