using Entidades;
using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<Pedido> Inserir(Pedido pedido);
        Task<List<Pedido>> Listar(PedidoFiltroDTO pedidoFiltroDTO);
    }
}
