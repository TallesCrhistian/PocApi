using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IUnidadeDeTrabalho
    {
        Task CommitAsync();
        Task SaveChangesAsync();
        void Rollback();
    }
}
