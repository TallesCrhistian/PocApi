using Microsoft.EntityFrameworkCore;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Pagamento> Alterar(Pagamento pagamento)
        {
            _appDbContext.Set<Pagamento>().Update(pagamento);
            await _appDbContext.SaveChangesAsync();

            return pagamento;
        }

        public async Task<Pagamento> Deletar(int codigo)
        {
            Pagamento pagamento = await _appDbContext.Pagamentos.Where(x => x.IdPagamento == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            pagamento.Ativo = false;
            _appDbContext.Set<Pagamento>().Update(pagamento);

            if (pagamento != null) await _appDbContext.SaveChangesAsync();


            return pagamento;
        }

        public async Task<Pagamento> Inserir(Pagamento pagamento)
        {
            await _appDbContext.Set<Pagamento>().AddAsync(pagamento);
            await _appDbContext.SaveChangesAsync();

            return pagamento;
        }

        public async Task<List<Pagamento>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO)
        {
            IQueryable<Pagamento> pagamentos = _appDbContext.Pagamentos
             .Include(x => x.PedidosPagamento)
             .Where(x => pagamentoFiltroDTO.IdPagamento != 0 ? x.IdPagamento == pagamentoFiltroDTO.IdPagamento : true)
             .Where(x => pagamentoFiltroDTO.Ativo != null ? x.Ativo == pagamentoFiltroDTO.Ativo : true)
             .Where(x => string.IsNullOrWhiteSpace(pagamentoFiltroDTO.Descricao) ? x.Descricao == pagamentoFiltroDTO.Descricao : true);


            List<Pagamento> pagamento = await pagamentos
                .AsNoTracking()
                .ToListAsync();
            return pagamento;
        }

        public async Task<Pagamento> ObterPorCodigo(int codigo)
        {
            Pagamento pagamento = await _appDbContext.Pagamentos
                .Where(x => x.IdPagamento == codigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();
                
            if (pagamento != null) await _appDbContext.SaveChangesAsync();

            return pagamento;
        }
    }
}
