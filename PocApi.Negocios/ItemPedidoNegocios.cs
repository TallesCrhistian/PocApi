using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class ItemPedidoNegocios : IItemPedidosNegocios
    {
        private readonly IItemPedidoRepositorio _itemPedidoRepositorio;
        private readonly IMapper _mapper;

        public ItemPedidoNegocios(IItemPedidoRepositorio itemPedidoRepositorio, IMapper mapper)
        {
            _itemPedidoRepositorio = itemPedidoRepositorio;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Inserir(PedidoDTO pedidoDTO)
        {
            ItemPedidoDTO itemPedidoDTO = AdicionaValores(pedidoDTO);
            ItemPedido itemPedido = _mapper.Map<ItemPedido>(itemPedidoDTO);
            await _itemPedidoRepositorio.Inserir(itemPedido);
            return pedidoDTO;
        }

        public ItemPedidoDTO AdicionaValores(PedidoDTO pedidoDTO)
        {
            ItemPedidoDTO itemPedidoDTO = new ItemPedidoDTO();
            itemPedidoDTO.IdPedido = pedidoDTO.IdPedido;
            itemPedidoDTO.Ordem += 1;

            return itemPedidoDTO;
        }
    }
}