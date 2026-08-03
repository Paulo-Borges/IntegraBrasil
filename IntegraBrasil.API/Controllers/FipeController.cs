using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
