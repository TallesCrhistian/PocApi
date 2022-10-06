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
            _appDbContext.Database.BeginTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public void Rollback()
        {
            _appDbContext.Database.RollbackTransaction();
        }

        public async Task DeleteAsync()
        {
           await _appDbContext.Database.EnsureDeletedAsync();
        }
    }
}
