using System;

namespace PocApi.Compartilhado.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();        
        public DateTime Data { get; set; }
        public int Status { get; set; }
    }
}
