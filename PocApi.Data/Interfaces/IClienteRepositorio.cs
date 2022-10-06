using Entidades;
using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task <List<Cliente>> Listar(ClienteFiltroDTO clienteFiltroDTO);
        Task<Cliente> ObterPorCodigo(int idCliente);
        Task<Cliente> Deletar(int idCliente);

    }
}
