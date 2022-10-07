using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IPedidoServicos
    {
        Task<RespostaServicoDTO<PedidoDTO>> Iserir(PedidoDTO pedidoDTO);
    }
}
