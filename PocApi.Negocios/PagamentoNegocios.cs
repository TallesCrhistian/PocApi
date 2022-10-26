using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class PagamentoNegocios : IPagamentoNegocios
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        private readonly IMapper _mapper;
        public PagamentoNegocios(IPagamentoRepositorio pagamentoRepositorio, IMapper mapper)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
            _mapper = mapper;
        }

        public async Task<PagamentoDTO> Inserir(PagamentoDTO pagamentoDTO)
        {
            Pagamento pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            pagamento = await _pagamentoRepositorio.Inserir(pagamento);
            return _mapper.Map<PagamentoDTO>(pagamento);
        }
    }
}
