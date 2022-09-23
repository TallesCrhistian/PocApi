using PocApi.Data.Entidades;
using PocApi.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Task<Cliente> Alterar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            return new Cliente {IdCliente = 1, Nome= "clinte incluido com sucesso" };
        }

        public Task<List<Cliente>> Listar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> ObterPorCodigo(int idCliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
