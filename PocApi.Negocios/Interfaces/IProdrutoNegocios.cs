using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IProdrutoNegocios
    {
        Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> ObterPorCodigo(int codigo);
        Task<ProdutoDTO> Deletar(int codigo);
        Task<ProdutoDTO> Alterar(ProdutoDTO produtoDTO);
    }
}
