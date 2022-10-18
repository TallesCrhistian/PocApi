using Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Inserir(Usuario usuario);
        Task<Usuario> ObterPorEmail(string email);
    }
}
