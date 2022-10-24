using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IProdutoServicos
    {
        Task<RespostaServicoDTO<ProdutoDTO>> Inserir(ProdutoDTO produtoDTO);
        Task<RespostaServicoDTO<ProdutoDTO>> ObterPorCodigo(int codigo);
        Task<RespostaServicoDTO<ProdutoDTO>> Deletar(int codigo);
        Task<RespostaServicoDTO<ProdutoDTO>> Alterar(ProdutoDTO produtoDTO);
        Task<RespostaServicoDTO<List<ProdutoDTO>>> Listar(ProdutoFiltroDTO produtoFiltroDTO);
    }
}
