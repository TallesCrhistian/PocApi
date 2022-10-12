using PocApi.Compartilhado.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        [ForeignKey("IdCliente")]
        [Required]
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
