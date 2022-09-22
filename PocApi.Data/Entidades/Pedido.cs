using System;
using System.ComponentModel.DataAnnotations;

namespace PocApi.Data.Entidades
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
    }
}
