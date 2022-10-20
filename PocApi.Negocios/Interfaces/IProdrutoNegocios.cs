using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IProdrutoNegocios
    {
        Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO);
    }
}
