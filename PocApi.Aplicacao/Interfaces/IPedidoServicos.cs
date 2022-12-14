using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocApi.Compartilhado.ModeloDeVisualizacao.Pedido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IPedidoServicos
    {
        Task<RespostaServicoDTO<PedidoDTO>> Inserir(PedidoInserirViewModel pedidoInserirViewModel);

        Task<RespostaServicoDTO<List<PedidoDTO>>> Listar(PedidoFiltroDTO pedidofiltroDTO);

        Task<RespostaServicoDTO<PedidoDTO>> Alterar(PedidoDTO pedidoDTO);

        Task<RespostaServicoDTO<PedidoDTO>> ObterPorCodigo(int codigo);

        Task<RespostaServicoDTO<PedidoDTO>> Deletar(int codigo);
    }
}