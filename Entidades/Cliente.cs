using PocApi.Entidades;
using System.Collections.Generic;

namespace Entidades
{
    public class Cliente
    {
        public bool? Ativo { get; set; } = true;
        public string Cpf { get; set; }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public virtual List<DocumentoAReceber> DocumentoAReceber { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}