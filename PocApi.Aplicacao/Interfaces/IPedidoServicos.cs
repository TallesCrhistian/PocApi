using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IPedidoServicos
    {
        Task<RespostaServicoDTO<PedidoDTO>> Inserir(PedidoDTO pedidoDTO);
        Task<RespostaServicoDTO<List<PedidoDTO>>> Listar(PedidoFiltroDTO pedidofiltroDTO);
        Task<RespostaServicoDTO<PedidoDTO>> Alterar(PedidoDTO pedidoDTO);
        Task<RespostaServicoDTO<PedidoDTO>> ObterPorCodigo(int codigo);
        Task<RespostaServicoDTO<PedidoDTO>> Deletar(PedidoDTO pedidoDTO);
    }
}
