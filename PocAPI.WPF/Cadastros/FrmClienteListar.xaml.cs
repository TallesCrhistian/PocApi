using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Enumeradores;
using PocApi.Compartilhado.Menssagens;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocApi.Utils.Extencoes;
using PocAPI.WPF.ChamadaAPI;
using PocAPI.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            if (ExibirFrmClienteCadastrar(new ClienteViewModel()))
            {
                btnPesquisar.PerformClick();
            }
        }

        private bool ExibirFrmClienteCadastrar(ClienteViewModel clienteViewModel)
        {
            FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente(clienteViewModel);
            bool? resultado = frmCadastroCliente.ShowDialog();
            return resultado == true;
        }

        private void dgvCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularComboBoxTipoPesquisa();
        }

        private void PopularComboBoxTipoPesquisa()
        {
            List<string> tipoPesquisa = new List<string>();
            tipoPesquisa.Add(TipoPesquisaClienteEnum.Id.ObterDescricao());
            tipoPesquisa.Add(TipoPesquisaClienteEnum.Nome.ObterDescricao());
            tipoPesquisa.Add(TipoPesquisaClienteEnum.SobreNome.ObterDescricao());
            tipoPesquisa.Add(TipoPesquisaClienteEnum.Cpf.ObterDescricao());

            cbxPesquisarPor.ItemsSource = tipoPesquisa;
            cbxPesquisarPor.SelectedIndex = 0;
        }

        private async void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            ClienteFiltroViewModel clienteFiltroViewModel = CriarClienteFiltroViewModel();
            List<ClienteViewModel> clienteViewModels = await Listar(clienteFiltroViewModel);

            dgvCliente.ItemsSource = clienteViewModels;
        }

        private ClienteFiltroViewModel CriarClienteFiltroViewModel()
        {
            string pesquisa = txtPesquisa.Text;
            TipoPesquisaClienteEnum tipoPesquisa = cbxPesquisarPor.SelectedValue.ToString().ObterValorPorDescricao<TipoPesquisaClienteEnum>();

            ClienteFiltroViewModel clienteFiltroViewModel = new ClienteFiltroViewModel
            {
                IdCliente = tipoPesquisa == TipoPesquisaClienteEnum.Id && Int32.TryParse(pesquisa, out int i) ? i : 0,
                Nome = tipoPesquisa == TipoPesquisaClienteEnum.Nome ? pesquisa : string.Empty,
                SobreNome = tipoPesquisa == TipoPesquisaClienteEnum.SobreNome ? pesquisa : string.Empty,
                Cpf = tipoPesquisa == TipoPesquisaClienteEnum.Cpf ? pesquisa : string.Empty
            };

            return clienteFiltroViewModel;
        }

        private async Task<List<ClienteViewModel>> Listar(ClienteFiltroViewModel clienteFiltroViewModel)
         {
            ClienteChamadaAPI clienteChamadaAPI = new ClienteChamadaAPI();
            RespostaServicoDTO<List<ClienteViewModel>> respostaServicoDTO = await clienteChamadaAPI.Listar(clienteFiltroViewModel);
            List<ClienteViewModel> clienteViewModels = respostaServicoDTO.Dados;

            return clienteViewModels;
        }

        private ClienteViewModel RetornaClienteViewModelSelecionado()
        {
            ClienteViewModel clienteViewModel = (ClienteViewModel)dgvCliente.SelectedItem;

            return clienteViewModel;
        }

        private bool ValidaClienteSelecionado(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel == null)
            {
                MessageBox.Show(this, ConstantesMensagens.NenhumRegistroSelecionado, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            ClienteViewModel clienteViewModel = RetornaClienteViewModelSelecionado();
            if (ValidaClienteSelecionado(clienteViewModel))
            {
                bool resultado = ExibirFrmClienteCadastrar(clienteViewModel);
                if (resultado)
                {
                    btnPesquisar.PerformClick();
                }
            }
        }
    }
}