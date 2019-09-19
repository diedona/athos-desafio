using DDonah.AthosDesafio.Services;
using Microsoft.AspNetCore.Mvc;

namespace DDonah.AthosDesafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAdministradoraService _administradoraService;

        public ValuesController(IAdministradoraService administradoraService)
        {
            _administradoraService = administradoraService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_administradoraService.GetAll());
        }
    }
}
