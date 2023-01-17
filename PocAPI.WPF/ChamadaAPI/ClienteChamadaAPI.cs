using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocAPI.ClienteAPI;
using PocAPI.WPF.Configuracoes;
using System.Collections.Generic;
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
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/Inserir";
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.PostAsync<ClienteViewModel, ClienteViewModel>(url, clienteViewModel);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteViewModel>> Alterar(ClienteViewModel clienteViewModel)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/Alterar";
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.PutAsync<ClienteViewModel, ClienteViewModel>(url, clienteViewModel);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<ClienteViewModel>> Deletar(int idCliente)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/" + idCliente;
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<ClienteViewModel> respostaServicoDTO = await conexaoAPI.DeleteAsync<ClienteViewModel>(url);

            return respostaServicoDTO;
        }

        public async Task<RespostaServicoDTO<List<ClienteViewModel>>> Listar(ClienteFiltroViewModel clienteFiltroViewModel)
        {
            string url = ConfiguracoesWPF.EnderecoBase + "api/cliente/Listar";
            ConexaoAPI conexaoAPI = new ConexaoAPI(string.Empty);
            RespostaServicoDTO<List<ClienteViewModel>> respostaServicoDTO = await conexaoAPI.PostAsync<List<ClienteViewModel>, ClienteFiltroViewModel>(url, clienteFiltroViewModel);

            return respostaServicoDTO;
        }
    }
}