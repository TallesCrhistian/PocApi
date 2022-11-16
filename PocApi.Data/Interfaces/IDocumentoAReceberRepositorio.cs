using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IDocumentoAReceberRepositorio
    {
        Task<DocumentoAReceber> Inserir(DocumentoAReceber documentoAReceber);
    }
}
