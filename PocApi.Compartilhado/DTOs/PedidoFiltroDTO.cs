using PocApi.Compartilhado.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Compartilhado.DTOs
{
    public class PedidoFiltroDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }
    }
}
