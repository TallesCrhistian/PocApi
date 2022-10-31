using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class PedidoPagamentoNegocios : IPedidoPagamentoNegocios
    {
        private readonly IMapper _mapper;
        private readonly IPedidoPagamentoRepositorio _pedidoPagamentoRepositorio;

        public PedidoPagamentoNegocios(IMapper mapper, IPedidoPagamentoRepositorio pedidoPagamentoRepositorio)
        {
            _mapper = mapper;
            _pedidoPagamentoRepositorio = pedidoPagamentoRepositorio;
        }
        public async Task<PedidoPagamentoDTO> Inserir(PedidoPagamentoDTO pedidoPagamentoDTO)
        {
            PedidoPagamento pedidopagamento = _mapper.Map<PedidoPagamento>(pedidoPagamentoDTO);
            pedidopagamento = await _pedidoPagamentoRepositorio.Inserir(pedidopagamento);
            return _mapper.Map<PedidoPagamentoDTO>(pedidopagamento);
        }
    }
}
