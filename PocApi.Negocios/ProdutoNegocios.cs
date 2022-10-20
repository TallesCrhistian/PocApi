using PocApi.Compartilhado.DTOs;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class ProdutoNegocios : IProdrutoNegocios
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO)
        {
            
        }
    }
}
