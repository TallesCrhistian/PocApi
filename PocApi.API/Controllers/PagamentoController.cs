using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using System.Threading.Tasks;

namespace PocApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoServicos _pagamentoServico;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoServicos pagamentoServico, IMapper mapper)
        {
            _pagamentoServico = pagamentoServico;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir(PagamentoInserirViewModel pagamentoInserirViewModel)
        {
            PagamentoDTO pagamentoDTO = _mapper.Map<PagamentoDTO>(pagamentoInserirViewModel);
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = await _pagamentoServico.Inserir(pagamentoDTO);
            return Ok(respostaServicoDTO);
        }
        [HttpPut("{codigo:int}")]
        public async Task<IActionResult> ObeterPorCodigo(int codigo)
        {
            RespostaServicoDTO<PagamentoDTO> respostaServicoDTO = await _pagamentoServico.ObterPorCodigo(codigo);
            return Ok(respostaServicoDTO);
        }
    }
}
