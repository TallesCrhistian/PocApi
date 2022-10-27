using PocApi.Compartilhado.DTOs;
using PocApi.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<Pagamento> Inserir(Pagamento pagamento);
        Task<Pagamento> ObterPorCodigo(int codigo);
        Task<List<Pagamento>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO);
        Task<Pagamento> Deletar(int codigo);
        Task<Pagamento> Alterar(Pagamento pagamento);
    }
}
