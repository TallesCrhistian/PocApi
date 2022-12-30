using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocAPI.WPF.ChamadaAPI;
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
    /// Lógica interna para FrmClienteListar.xaml
    /// </summary>
    public partial class FrmClienteListar : Window
    {
        public FrmClienteListar()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            ExibirCadastroCliente();
        }

        private bool ExibirCadastroCliente()
        {
            FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente();
            frmCadastroCliente.Owner = this;
            bool? resultado = frmCadastroCliente.ShowDialog();
            return resultado == true;
        }

        private void dgvCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClienteChamadaAPI clienteChamadaAPI = new ClienteChamadaAPI();
            ClienteDTO clienteDTO = new ClienteDTO { IdCliente = 1, Cpf = "112", Nome = "talles", SobreNome = " arriel" };
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await clienteChamadaAPI.Alterar(clienteDTO);

            MessageBox.Show("Nome: " + respostaServicoDTO.Dados.Nome);
        }
    }
}