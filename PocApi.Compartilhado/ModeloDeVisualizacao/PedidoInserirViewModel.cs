using PocApi.Compartilhado.Enumeradores;
using System;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PedidoInserirViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public DateTime Data { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
