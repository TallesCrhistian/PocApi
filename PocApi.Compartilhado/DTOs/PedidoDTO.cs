using System;

namespace PocApi.Compartilhado.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal Frete { get; set; }
        public ClienteDTO ClienteDTO { get; set; } 
        public DateTime Data { get; set; }
        public int Status { get; set; }
    }
}
