using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _appDbContext.Set<Cliente>().Update(cliente);
            await _appDbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            await _appDbContext.Set<Cliente>().AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
            
            return cliente;
        }

        public async Task<List<Cliente>> Listar(ClienteFiltroDTO clienteFiltroDTO)
        {
            IQueryable<Cliente> clientes = _appDbContext.Clientes
                .Where(x => clienteFiltroDTO.IdCliente != 0 ? x.IdCliente == clienteFiltroDTO.IdCliente : true)
                .Where(x => clienteFiltroDTO.Ativo != null ? x.Ativo == clienteFiltroDTO.Ativo : (x.Ativo == true || x.Ativo == false))
                .Where(x => clienteFiltroDTO.Nome != null ? x.Nome == clienteFiltroDTO.Nome : true)
                .Where(x => clienteFiltroDTO.SobreNome != null ? x.SobreNome == clienteFiltroDTO.SobreNome : true)
                .Where(x => clienteFiltroDTO.Cpf != null ? x.Cpf == clienteFiltroDTO.Cpf : true);
            
            List<Cliente> cliente = await clientes
                .AsNoTracking()
                .ToListAsync();
            return cliente;
            
        }

        public Task<Cliente> ObterPorCodigo(int idCliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
