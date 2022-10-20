using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.Data.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public ProdutoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Produto> Inserir(Produto produto)
        {
            await _appDbContext.Set<Produto>().AddAsync(produto);
            await _appDbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> ObterPorCodigo(int codigo)
        {
            Produto produto = await _appDbContext.Produtos.Where(x => x.IdProduto == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (produto != null) await _appDbContext.SaveChangesAsync();


            return produto;
        }
    }
}
