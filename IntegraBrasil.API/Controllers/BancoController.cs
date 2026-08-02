using IntegraBrasil.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace IntegraBrasil.API.Controllers
{
    //Data notation do controller
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("busca/todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _bancoService.BuscarTodos();
            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErrosRetorno);
            }
        }

        [HttpGet("busca/{codigoBanco}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Buscar([RegularExpression("^[0-9]*$")] string codigoBanco)
        {
            var response = await _bancoService.BuscarBanco(codigoBanco);
            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErrosRetorno);
            }
        }

    }
}
