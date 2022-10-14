using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public bool? Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
