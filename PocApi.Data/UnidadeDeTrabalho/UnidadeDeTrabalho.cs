using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Data.UnidadeDeTrabalho
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly AppDbContext _appDbContext;
        public UnidadeDeTrabalho(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            
        }
    }
}
