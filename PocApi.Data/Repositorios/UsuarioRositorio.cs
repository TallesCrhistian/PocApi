using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class UsuarioRositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Usuario> Inserir(Usuario usuario)
        {
            await _appDbContext.Set<Usuario>().AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            Usuario usuario = await _appDbContext
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

            return usuario;
        }
    }
}
