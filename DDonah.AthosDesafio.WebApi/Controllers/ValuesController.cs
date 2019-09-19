using AutoMapper;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDonah.AthosDesafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAdministradoraService _administradoraService;
        private readonly IMapper _mapper;

        public ValuesController(IAdministradoraService administradoraService, IMapper mapper)
        {
            _administradoraService = administradoraService;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var model = _administradoraService.GetAll();
            var vm = _mapper.Map<IEnumerable<AdministradoraViewModel>>(model);
            return Ok(vm);
        }
    }
}
