using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IPedidoNegocios
    {
        Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO);
        Task<List<PedidoDTO>> Listar(PedidoFiltroDTO pedidoFiltroDTO);
        Task<PedidoDTO> ObterPorCodigo(int codigo);
        Task<PedidoDTO> Alterar(PedidoDTO pedidoDTO);
    }
}
