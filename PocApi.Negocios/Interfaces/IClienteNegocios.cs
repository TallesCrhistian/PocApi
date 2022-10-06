using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IClienteNegocios
    {
        Task<ClienteDTO> Inserir(ClienteDTO clienteDTO);
        Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
        Task<List<ClienteDTO>> Listar(ClienteFiltroDTO clienteDTO);
        Task<ClienteDTO> ObterPorCodigo(int codigo);
        Task<ClienteDTO> Deletar(int idCliente);
    }
}
