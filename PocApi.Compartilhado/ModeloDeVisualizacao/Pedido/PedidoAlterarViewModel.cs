using PocApi.Compartilhado.Enumeradores;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoAlterarViewModel
    {
        public int IdPedido { get; set; }        
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
