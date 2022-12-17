using System.Windows;

namespace PocAPI.WPF.Configuracoes
{
    /// <summary>
    /// Lógica interna para FrmValidar.xaml
    /// </summary>
    public partial class FrmValidar : Window
    {
        public FrmValidar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}