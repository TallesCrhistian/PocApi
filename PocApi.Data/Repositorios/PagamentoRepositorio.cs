using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public PagamentoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Pagamento> Inserir(Pagamento pagamento)
        {
            await _appDbContext.Set<Pagamento>().AddAsync(pagamento);
            await _appDbContext.SaveChangesAsync();

            return pagamento;
        }
    }
}
