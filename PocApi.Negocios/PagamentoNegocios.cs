using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System.Collections.Generic;
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

        public async Task<PagamentoDTO> Alterar(PagamentoDTO pagamentoDTO)
        {
            if (!await Validar(pagamentoDTO))
            {
                return pagamentoDTO;
            }
            Pagamento pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            pagamento = await _pagamentoRepositorio.Alterar(pagamento);
            return _mapper.Map<PagamentoDTO>(pagamento);
        }

        public async Task<PagamentoDTO> Deletar(int codigo)
        {
            Pagamento pagamento = await _pagamentoRepositorio.Deletar(codigo);
            
            return _mapper.Map<PagamentoDTO>(pagamento);
        }

        public async Task<PagamentoDTO> Inserir(PagamentoDTO pagamentoDTO)
        {
            Pagamento pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            pagamento = await _pagamentoRepositorio.Inserir(pagamento);
            return _mapper.Map<PagamentoDTO>(pagamento);
        }

        public async Task<List<PagamentoDTO>> Listar(PagamentoFiltroDTO pagamentoFiltroDTO)
        {
            List<Pagamento> pagamento = await _pagamentoRepositorio.Listar(pagamentoFiltroDTO);
            return _mapper.Map<List<PagamentoDTO>>(pagamento);
        }

        public async Task<PagamentoDTO> ObterPorCodigo(int codigo)
        {
            Pagamento pagamento = await _pagamentoRepositorio.ObterPorCodigo(codigo);
            PagamentoDTO pagamentoDTO = (pagamento != null) ? _mapper.Map<PagamentoDTO>(pagamento) : new PagamentoDTO();
            return pagamentoDTO;
        }
        public async Task<bool> Validar(PagamentoDTO pagamentoDTO)
        {
            bool pagamentoValido = true;
            Pagamento pagamento = await _pagamentoRepositorio.ObterPorCodigo(pagamentoDTO.IdPagamento);
            if (pagamento == null || pagamento.IdPagamento == 0)
            {
                pagamentoValido = false;
            }
            return pagamentoValido;
        }
    }
}
