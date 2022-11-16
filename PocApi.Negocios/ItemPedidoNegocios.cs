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

        public async Task<ItemPedidoDTO> Inserir(ItemPedidoDTO itemPedidoDTO)
        {
            ItemPedido itemPedido  = _mapper.Map<ItemPedido>(itemPedidoDTO);
            itemPedido = await _itemPedidoRepositorio.Inserir(itemPedido);            
            return _mapper.Map<ItemPedidoDTO>(itemPedido);
        }
    }
}
