using PocApi.Compartilhado.Enumeradores;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoInserirViewModel
    {
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
