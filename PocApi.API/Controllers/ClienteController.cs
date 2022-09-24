using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.Aplicacao.Servicos;
using PocApi.Compartilhado.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
