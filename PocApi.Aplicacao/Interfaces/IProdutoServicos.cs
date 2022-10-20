using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IProdutoServicos
    {
        Task<RespostaServicoDTO<ProdutoDTO>> Inserir(ProdutoDTO produtoDTO);
        Task<RespostaServicoDTO<ProdutoDTO>> ObterPorCodigo(int codigo);
    }
}
