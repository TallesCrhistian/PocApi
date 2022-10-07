using PocApi.Compartilhado.DTOs;
using PocApi.Data.UnidadeDeTrabalho.Interfaces;
using PocApi.Negocios.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class PedidoNegocios : IPedidoNegocios
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO)
        {
            throw new System.NotImplementedException();
        }

    }
}
