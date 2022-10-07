using PocApi.Compartilhado.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
