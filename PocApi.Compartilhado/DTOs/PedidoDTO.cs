using System;
using System.Collections.Generic;

namespace PocApi.Compartilhado.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal Frete { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
        public virtual List<PedidoPagamentoDTO> PedidosPagamentoDTO  { get; set; }
        public List<ItemPedidoDTO> ItemPedidoDTO { get; set; }
        public virtual DocumentoAReceberDTO DocumentoAReceberDTO { get; set; }
    }
}
