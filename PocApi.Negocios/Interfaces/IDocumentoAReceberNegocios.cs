using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios.Interfaces
{
    public interface IDocumentoAReceberNegocios
    {
        Task<DocumentoAReceberDTO> Inserir(DocumentoAReceberDTO documentoAReceberDTO);

        List<DocumentoAReceberDTO> CriarDocumentoAReceberDTO(PedidoDTO pedidoDTO);
    }
}