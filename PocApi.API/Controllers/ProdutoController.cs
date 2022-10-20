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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServicos _produtoServicos;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoServicos produtoServicos, IMapper mapper)
        {
            _produtoServicos = produtoServicos;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir(ProdutoInserirViewModel produtoInserirViewModel)
        {
            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produtoInserirViewModel);
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = await _produtoServicos.Inserir(produtoDTO);
            return Ok(respostaServicoDTO);
        }
        [HttpPost("{codigo:int}")]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = await _produtoServicos.ObterPorCodigo(codigo);
            return Ok(respostaServicoDTO);
        }
    }
}
