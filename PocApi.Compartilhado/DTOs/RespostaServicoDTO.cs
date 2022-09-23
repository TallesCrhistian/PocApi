using PocApi.Compartilhado.Menssagens;
namespace PocApi.Compartilhado.DTOs
{
    public class RespostaServicoDTO<T>
    {
        public T Dados { get; set; }
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = ConstantesMensagens.OperacaoConcluidaComSucesso;
    }
}

