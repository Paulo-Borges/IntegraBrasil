using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegraBrasil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FipeController : ControllerBase
    {
        private readonly IFipeService _fipeService;
        public FipeController(IFipeService fipeService)
        {
            _fipeService = fipeService;
        }
        [HttpGet("busca/{veiculo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarFipe(string veiculo)
        {
            var response = await _fipeService.BuscarFipe(veiculo);
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
