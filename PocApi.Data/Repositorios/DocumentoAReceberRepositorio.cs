using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class DocumentoAReceberRepositorio : IDocumentoAReceberRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public DocumentoAReceberRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<DocumentoAReceber> Inserir(DocumentoAReceber documentoAReceber)
        {
            await _appDbContext.Set<DocumentoAReceber>().AddAsync(documentoAReceber);
            await _appDbContext.SaveChangesAsync();

            return documentoAReceber;
        }
    }
}
