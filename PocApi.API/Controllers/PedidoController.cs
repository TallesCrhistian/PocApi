using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class PedidoController : ControllerBase

    {
        private readonly IPedidoServicos _pedidoServicos;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoServicos pedidoServicos, IMapper mapper)
        {
            _pedidoServicos = pedidoServicos;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir([FromBody] PedidoInserirViewModel pedidoInserirViewModel)
        {
            PedidoDTO pedidoDTO = _mapper.Map<PedidoDTO>(pedidoInserirViewModel);
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = await _pedidoServicos.Inserir(pedidoDTO);
            return Ok(respostaServicoDTO);
        }

        [HttpPost]
        [Route(nameof(Listar))]
        public async Task<IActionResult> Listar([FromBody] PedidoFiltroDTO pedidoFiltroDTO)
        {
            RespostaServicoDTO<List<PedidoDTO>> respostaServicoDTO = await _pedidoServicos.Listar(pedidoFiltroDTO);
            return Ok(respostaServicoDTO);
        }
        [HttpPut]
        [Route(nameof(Alterar))]
        public async Task<IActionResult> Alterar([FromBody] PedidoAlterarViewModel pedidoAlterarViewModel)
        {
            PedidoDTO pedidoDTO = _mapper.Map<PedidoDTO>(pedidoAlterarViewModel);
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = await _pedidoServicos.Alterar(pedidoDTO);

            return Ok(respostaServicoDTO);
        }
        [HttpPost("{codigo:int}")]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = await _pedidoServicos.ObterPorCodigo(codigo);
            return Ok(respostaServicoDTO);
        }
        [HttpDelete("{codigo:int}")]
        public async Task<IActionResult> Deletar(int codigo)
        {            
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = await _pedidoServicos.Deletar(codigo);

            return Ok(respostaServicoDTO);
        }


    }
}
