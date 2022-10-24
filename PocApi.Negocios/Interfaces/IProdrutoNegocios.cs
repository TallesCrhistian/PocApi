using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IProdrutoNegocios
    {
        Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> ObterPorCodigo(int codigo);
        Task<ProdutoDTO> Deletar(int codigo);
        Task<ProdutoDTO> Alterar(ProdutoDTO produtoDTO);
        Task<List<ProdutoDTO>> Listar(ProdutoFiltroDTO produtoFiltroDTO);
    }
}
