using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using System.Collections.Generic;
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
        public async Task<IActionResult> Inserir([FromBody] ProdutoInserirViewModel produtoInserirViewModel)
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

        [HttpDelete("{codigo:int}")]
        public async Task<IActionResult> Deletar(int codigo)
        {
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = await _produtoServicos.Deletar(codigo);
            return Ok(respostaServicoDTO);
        }

        [HttpPut]
        [Route(nameof(Alterar))]
        public async Task<IActionResult> Alterar([FromBody] ProdutoAlterarViewModel produtoAlterarViewModel)
        {
            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produtoAlterarViewModel);
            RespostaServicoDTO<ProdutoDTO> respostaServicoDTO = await _produtoServicos.Alterar(produtoDTO);
            return Ok(respostaServicoDTO);
        }

        [HttpPost]
        [Route(nameof(Listar))]
        public async Task<IActionResult> Listar([FromBody] ProdutoFiltroViewModel produtoFiltroViewModel)
        {
            ProdutoFiltroDTO produtoFiltroDTO = _mapper.Map<ProdutoFiltroDTO>(produtoFiltroViewModel);
            RespostaServicoDTO<List<ProdutoDTO>> respostaServicoDTO = await _produtoServicos.Listar(produtoFiltroDTO);
            return Ok(respostaServicoDTO);
        }
    }
}