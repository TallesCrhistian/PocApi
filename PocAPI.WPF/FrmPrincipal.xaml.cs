﻿using PocAPI.WPF.Cadastros;
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
            FrmClienteListar frmClienteListar = new FrmClienteListar();
            frmClienteListar.Owner = this;
            frmClienteListar.Show();
        }

        private void Produtos_Click(object sender, RoutedEventArgs e)
        {
            Produtos produtos = new Produtos();
            produtos.Owner = this;
            produtos.Show();
        }

        private void Pagamento_Click(object sender, RoutedEventArgs e)
        {
            Pagamentos pagamentos = new Pagamentos();
            pagamentos.Owner = this;
            pagamentos.Show();
        }

        private void Pedido_Click(object sender, RoutedEventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Owner = this;
            pedido.Show();
        }

        private void DocumentoAReceber_Click(object sender, RoutedEventArgs e)
        {
            DocumentosAReceber documentoAReceber= new DocumentosAReceber();
            documentoAReceber.Owner = this;
            documentoAReceber.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           bool resultado = ExibirFrmLogin();
            if (resultado == false)
            {
                Close();
            }
        }
        private bool ExibirFrmLogin()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Owner = this;
            bool? resultado = frmLogin.ShowDialog();
            return resultado == true;
        }
    }
}
