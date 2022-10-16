using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System.Collections.Generic;
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

        public async Task<PedidoDTO> Alterar(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
            pedido = await _pedidoRepositorio.Alterar(pedido);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
            pedido = await _pedidoRepositorio.Inserir(pedido);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<List<PedidoDTO>> Listar(PedidoFiltroDTO pedidoFiltroDTO)
        {
            List<Pedido> pedido = await _pedidoRepositorio.Listar(pedidoFiltroDTO);
            List<PedidoDTO> pedidoDTO = _mapper.Map<List<PedidoDTO>>(pedido);
            return pedidoDTO;
        }

        public async Task<PedidoDTO> ObterPorCodigo(int codigo)
        {
            Pedido pedido = await _pedidoRepositorio.ObterPorCodigo(codigo);
            PedidoDTO pedidoDTO = (pedido != null) ? _mapper.Map<PedidoDTO>(pedido) : new PedidoDTO();
            return pedidoDTO;
        }
    }
}
