using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Interfaces
{
    public interface IPagamentoServicos
    {
        Task<RespostaServicoDTO<PagamentoDTO>> Inserir(PagamentoDTO pagamentoDTO);
        Task<RespostaServicoDTO<PagamentoDTO>> ObterPorCodigo(int codigo);
    }
}
