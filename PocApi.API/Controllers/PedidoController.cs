using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        [Route(nameof(Iserir))]
        public async Task<IActionResult> Iserir([FromBody] PedidoInserirViewModel pedidoInserirViewModel)
        {
            return Ok("");
        }
    }
}
