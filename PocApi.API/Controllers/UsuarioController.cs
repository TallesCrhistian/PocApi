using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServicos usuarioServicos, IMapper mapper)
        {
            _usuarioServicos = usuarioServicos;
            _mapper = mapper;
        }

        [HttpPost]
        [Route (nameof(Registrar))]

        public async Task<IActionResult> Registrar([FromBody] UsuarioInserirViewModel usuarioInserirViewModel)
        {
            UsuarioDTO usuarioDTO =  _mapper.Map<UsuarioDTO>(usuarioInserirViewModel);
            RespostaServicoDTO<UsuarioDTO> respostaServicoDTO = await _usuarioServicos.Registrar(usuarioDTO);            
            return Ok(respostaServicoDTO);
        }
        [HttpPost]
        [Route(nameof(Login))]

        public async Task<IActionResult> Login([FromBody] UsuarioInserirViewModel usuarioInserirViewModel)
        {
            UsuarioDTO usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioInserirViewModel);
            RespostaServicoDTO<UsuarioDTO> respostaServicoDTO = await _usuarioServicos.Login(usuarioDTO);
            return Ok(respostaServicoDTO);
        }
    }
}
