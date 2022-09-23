using PocApi.Data.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task <List<Cliente>> Listar(Cliente cliente);
        Task<Cliente> ObterPorCodigo(int idCliente);

    }
}
