using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegraBrasil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambioController : ControllerBase
    {
        private readonly ICambioService _cambioService;
        public CambioController(ICambioService cambioService)
        {
            _cambioService = cambioService;
        }
        [HttpGet("moeda")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCambio()
        {
            var response = await _cambioService.BuscarCambio();
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