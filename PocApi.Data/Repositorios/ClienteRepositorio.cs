using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System;
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

        public async Task<Cliente> Deletar(int idCliente)
        {

            Cliente cliente = await _appDbContext.Clientes.Where(x => x.IdCliente == idCliente).FirstOrDefaultAsync();
            if (cliente != null)
            {
                cliente.Ativo = false;
                _appDbContext.Set<Cliente>().Update(cliente);
                await _appDbContext.SaveChangesAsync();
            }

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
                .Where(x => clienteFiltroDTO.Ativo != null ? x.Ativo == clienteFiltroDTO.Ativo : true)
                .Where(x => string.IsNullOrWhiteSpace(clienteFiltroDTO.Nome) ? x.Nome == clienteFiltroDTO.Nome : true)
                .Where(x => string.IsNullOrWhiteSpace(clienteFiltroDTO.SobreNome) ? x.SobreNome == clienteFiltroDTO.SobreNome : true)
                .Where(x => string.IsNullOrWhiteSpace(clienteFiltroDTO.Cpf) ? x.Cpf == clienteFiltroDTO.Cpf : true);

            List<Cliente> cliente = await clientes
                .AsNoTracking()
                .ToListAsync();
            return cliente;

        }

        public async Task<Cliente> ObterPorCodigo(int idCliente)
        {
            Cliente cliente = await _appDbContext.Clientes.Where(x => x.IdCliente == idCliente).FirstOrDefaultAsync();
            if (cliente != null) await _appDbContext.SaveChangesAsync();

            return cliente;
        }
    }
}
