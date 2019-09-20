using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.WebApi.Controllers.Base;
using DDonah.AthosDesafio.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDonah.AthosDesafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoraController : BaseApiController
    {
        private readonly IAdministradoraService _administradoraService;

        public AdministradoraController(IMapper mapper, IAdministradoraService administradoraService) : base(mapper)
        {
            _administradoraService = administradoraService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _administradoraService.GetAll();
            var vmList = _mapper.Map<IEnumerable<AdministradoraViewModel>>(list);
            return Ok(vmList);
        }
    }
}