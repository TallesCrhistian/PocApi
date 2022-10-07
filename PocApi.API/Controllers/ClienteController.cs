﻿using Microsoft.AspNetCore.Mvc;
using PocApi.Aplicacao.Servicos;
using PocApi.Compartilhado.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteServicos _clienteServicos;


        public ClienteController(IClienteServicos clienteServicos)
        {
            _clienteServicos = clienteServicos;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir([FromBody] ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = await _clienteServicos.Inserir(clienteDTO);

            return Ok(respostaServicoDTO);

        }

        [HttpPut]
        [Route(nameof(Alterar))]
        public async Task<IActionResult> Alterar([FromBody] ClienteDTO clienteDTO)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = await _clienteServicos.Alterar(clienteDTO);

            return Ok(respostaServicoDTO);
        }

        [HttpPost]
        [Route(nameof(Listar))]
        public async Task<IActionResult> Listar([FromBody] ClienteFiltroDTO clienteFiltroDTO)
        {
            RespostaServicoDTO<List<ClienteDTO>> respostaServicoDTO = await _clienteServicos.Listar(clienteFiltroDTO);
            return Ok(respostaServicoDTO);
        }

        [HttpDelete("{idCliente:int}")]
        public async Task<ActionResult> Deletar(int idCliente)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = await _clienteServicos.Deletar(idCliente);
            return Ok(respostaServicoDTO);
        }
        [HttpPost("{idCliente:int}")]
        public async Task<IActionResult> ObterPorCodigo(int idCliente)
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = await _clienteServicos.ObterPorCodigo(idCliente);
            return Ok(respostaServicoDTO);
        }
    }
}
