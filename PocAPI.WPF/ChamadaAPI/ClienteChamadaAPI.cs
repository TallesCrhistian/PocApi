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
    }
}