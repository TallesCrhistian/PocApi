using PocApi.Compartilhado.DTOs;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IDocumentoAReceberNegocios
    {
        Task<DocumentoAReceberDTO> Inserir(PagamentoDTO pagamentoDTO);
    }
}
