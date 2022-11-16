using PocAPI.WPF.Cadastros;
using PocAPI.WPF.Movimento;
using System.Windows;


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

        private void Produtos_Click(object sender, RoutedEventArgs e)
        {
            Produtos produtos = new Produtos();
            produtos.Owner = this;
            produtos.ShowDialog();
        }

        private void Pagamento_Click(object sender, RoutedEventArgs e)
        {
            Pagamentos pagamentos = new Pagamentos();
            pagamentos.Owner = this;
            pagamentos.ShowDialog();
        }

        private void Pedido_Click(object sender, RoutedEventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Owner = this;
            pedido.ShowDialog();
        }

        private void DocumentoAReceber_Click(object sender, RoutedEventArgs e)
        {
            DocumentosAReceber documentoAReceber= new DocumentosAReceber();
            documentoAReceber.Owner = this;
            documentoAReceber.ShowDialog();
        }
    }
}
