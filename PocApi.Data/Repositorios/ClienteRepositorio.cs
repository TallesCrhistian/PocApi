using Entidades;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private AppDbContext _appDbContext;

        public ClienteRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Cliente> Alterar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            await _appDbContext.Clientes.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
            return cliente;
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
