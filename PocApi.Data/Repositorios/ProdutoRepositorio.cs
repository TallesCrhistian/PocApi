using Entidades;
using Microsoft.EntityFrameworkCore;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using System.Collections.Generic;
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

        public async Task<Produto> Alterar(Produto produto)
        {
            _appDbContext.Set<Produto>().Update(produto);
            await _appDbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Deletar(int codigo)
        {
            Produto produto = await _appDbContext.Produtos.Where(x => x.IdProduto == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            produto.Ativo = false;

            if (produto != null) await _appDbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Inserir(Produto produto)
        {
            await _appDbContext.Set<Produto>().AddAsync(produto);
            produto.Ativo = true;
            await _appDbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<List<Produto>> Listar(ProdutoFiltroDTO produtoFiltroDTO)
        {
            IQueryable<Produto> produtos = _appDbContext.Produtos
            .Where(x => produtoFiltroDTO.IdProduto != 0 ? x.IdProduto == produtoFiltroDTO.IdProduto : true)
            .Where(x => produtoFiltroDTO.Ativo != null ? x.Ativo == produtoFiltroDTO.Ativo : true)
            .Where(x => string.IsNullOrWhiteSpace(produtoFiltroDTO.EAN) ? x.EAN == produtoFiltroDTO.EAN : true);

            List<Produto> produto = await produtos
                .AsNoTracking()
                .ToListAsync();

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