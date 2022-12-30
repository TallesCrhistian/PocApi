using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocAPI.ClienteAPI;
using PocAPI.WPF.Configuracoes;
using System.Threading.Tasks;

namespace PocAPI.WPF.ChamadaAPI
{
    public class ClienteChamadaAPI
    {
        public async Task<RespostaServicoDTO<ClienteViewModel>> ObterPorCodigo(int idCliente)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/" + idCliente;
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.GetAsync<ClienteViewModel>(url);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteViewModel>> Inserir(ClienteViewModel clienteViewModel)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/" + clienteViewModel.Nome;
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.PostAsync<ClienteViewModel, ClienteViewModel>(url, clienteViewModel);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteViewModel>> Alterar(ClienteDTO clienteDTO)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/" + clienteDTO.Nome;
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.PutAsync<ClienteViewModel, ClienteDTO>(url, clienteDTO);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteViewModel>> Deletar(int idCliente)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/" + idCliente;
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.DeleteAsync<ClienteViewModel>(url);

            return respostaServicoDTO;
        }
    }
}