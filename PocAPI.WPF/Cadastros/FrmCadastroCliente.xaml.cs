using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
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
    /// Lógica interna para FrmCadastroCliente.xaml
    /// </summary>
    public partial class FrmCadastroCliente : Window
    {
        private ClienteViewModel _clienteViewModel;

        public FrmCadastroCliente(ClienteViewModel clienteViewMode)
        {
            _clienteViewModel = clienteViewMode;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _clienteViewModel;
        }

        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (await Salvar())
            {
                this.DialogResult = true;
                MessageBox.Show(this, ConstantesMensagens.OperacaoConcluidaComSucesso, "Aviso", MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, ConstantesMensagens.NaoFoiPossivelConcluirOperacao, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async Task<bool> Salvar()
        {
            ClienteChamadaAPI clienteChamadaAPI = new ClienteChamadaAPI();
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = new RespostaServicoDTO<ClienteViewModel>();
            ClienteViewModel clienteViewModel = new ClienteViewModel();

            if (_clienteViewModel.IdCliente == 0)
            {
                respostaServicoDTO = await clienteChamadaAPI.Inserir(_clienteViewModel);
                clienteViewModel = respostaServicoDTO.Dados;
            }
            else
            {
                respostaServicoDTO = await clienteChamadaAPI.Alterar(_clienteViewModel);
                clienteViewModel = respostaServicoDTO.Dados;
            }

            return clienteViewModel.IdCliente > 0;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}