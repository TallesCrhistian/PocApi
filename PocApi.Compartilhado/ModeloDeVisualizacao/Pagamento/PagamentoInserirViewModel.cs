using PocApi.Compartilhado.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Compartilhado.ModeloDeVisualizacao
{
    public class PagamentoInserirViewModel
    {
        public PagamentoFormaEnum PagamentoForma { get; set; }
        public string Descricao { get; set; }
        public int DiasPagamento { get; set; }
        public decimal DiaJuros { get; set; }
        public decimal MultaAtraso { get; set; }
        public int DiasCarencia { get; set; }
        public int Parcelas { get; set; }
    }
}