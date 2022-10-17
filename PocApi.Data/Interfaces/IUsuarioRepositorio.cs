using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Inserir(Usuario usuario);
    }
}
