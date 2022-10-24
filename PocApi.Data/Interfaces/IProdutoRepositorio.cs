using Entidades;
using PocApi.Compartilhado.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
     public interface IProdutoRepositorio
    {
        Task<Produto> Inserir(Produto produto);
        Task<Produto> ObterPorCodigo(int codigo);
        Task<Produto> Deletar(int codigo);
        Task<Produto> Alterar(Produto produto);
        Task<List<Produto>> Listar(ProdutoFiltroDTO produtoFiltroDTO);
    }
}
