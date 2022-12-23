using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PocAPI.WPF.Cadastros
{
    /// <summary>
    /// Lógica interna para FrmPagamentosListar.xaml
    /// </summary>
    public partial class FrmPagamentosListar : Window
    {
        public FrmPagamentosListar()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            ExibirCadastroPagamento();
        }

        private bool ExibirCadastroPagamento()
        {
            FrmCadastroPagamento frmCadastroPagamento = new FrmCadastroPagamento();
            frmCadastroPagamento.Owner = this;
            bool? resultado = frmCadastroPagamento.ShowDialog();
            return resultado == true;
        }
    }
}