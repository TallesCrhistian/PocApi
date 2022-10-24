using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public interface IClienteServicos
    {
        Task<RespostaServicoDTO<ClienteDTO>> Inserir(ClienteDTO clienteDTO);
        Task<RespostaServicoDTO<ClienteDTO>> Alterar(ClienteDTO clienteDTO);
        Task<RespostaServicoDTO<List<ClienteDTO>>> Listar(ClienteFiltroDTO clienteDTO);
        Task<RespostaServicoDTO<ClienteDTO>> ObterPorCodigo(int codigo);
        Task<RespostaServicoDTO<ClienteDTO>> Deletar(int idCliente);
    }
}
