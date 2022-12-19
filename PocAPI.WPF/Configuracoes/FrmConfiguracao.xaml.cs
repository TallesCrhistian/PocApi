using System.Windows;

namespace PocAPI.WPF.Configuracoes
{
    /// <summary>
    /// Lógica interna para FrmValidar.xaml
    /// </summary>
    public partial class FrmConfiguracao : Window
    {
        public FrmConfiguracao()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Salvar();
            Close();
        }

        private void Salvar()
        {
            ConfiguracoesClientePocAPI configuracoesClientePocAPI = new ConfiguracoesClientePocAPI { EnderecoBase = txtEderecoBase.Text, TimeOutSegundos = txtTime.Text };

            Utils.JsonUtils.SerializarClass(configuracoesClientePocAPI, ConstantesWPF.CaminhoPastaConfiguracao + "\\" + nameof(ConfiguracoesClientePocAPI) + ".txt");

            this.DialogResult = true;
        }
    }
}