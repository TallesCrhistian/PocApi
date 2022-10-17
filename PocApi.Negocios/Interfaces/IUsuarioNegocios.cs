using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IUsuarioNegocios
    {
        Task<UsuarioDTO> Inserir(UsuarioDTO usuarioDTO);
    }
}
