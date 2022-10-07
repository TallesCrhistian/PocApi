using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class PedidoNegocios : IPedidoNegocios
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoNegocios(IPedidoRepositorio pedidoRepositorio, IMapper mapper)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
            pedido = await _pedidoRepositorio.Inserir(pedido);
            return _mapper.Map<PedidoDTO>(pedido);
        }

    }
}
