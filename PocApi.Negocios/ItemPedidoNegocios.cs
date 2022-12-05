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

        public async Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO)
        {
            ItemPedidoDTO itemPedidoDTO = AdicionaValores(produtoDTO);
            ItemPedido itemPedido = _mapper.Map<ItemPedido>(itemPedidoDTO);
            await _itemPedidoRepositorio.Inserir(itemPedido);
            return produtoDTO;
        }

        public ItemPedidoDTO AdicionaValores(ProdutoDTO produtoDTO)
        {
            ItemPedidoDTO itemPedidoDTO = new ItemPedidoDTO();
            itemPedidoDTO.IdPedido = 1;
            itemPedidoDTO.PrecoCusto = produtoDTO.PrecoCusto;
            itemPedidoDTO.PrecoVenda = produtoDTO.PrecoVenda;
            itemPedidoDTO.Ordem += 1;

            return itemPedidoDTO;
        }
    }
}