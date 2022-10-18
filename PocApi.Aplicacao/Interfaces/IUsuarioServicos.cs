using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IUsuarioServicos
    {
        Task<RespostaServicoDTO<UsuarioDTO>> Registrar(UsuarioDTO usuarioDTO);
        Task<RespostaServicoDTO<UsuarioDTO>> Login(UsuarioDTO usuarioDTO);
    }
}
