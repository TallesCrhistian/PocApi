using PocAPI.WPF.Cadastros;
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

namespace PocAPI.WPF
{
    /// <summary>
    /// Lógica interna para FrmPrincipal.xaml
    /// </summary>
    public partial class FrmPrincipal : Window
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void MeiCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Owner = this;
            frmLogin.ShowDialog();
        }
    }
}
