using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.WebApi.Controllers.Base;
using DDonah.AthosDesafio.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDonah.AthosDesafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : BaseApiController
    {
        private readonly ICondominioService _condominioService;

        public CondominioController(ICondominioService condominioService, IMapper mapper) : base(mapper)
        {
            _condominioService = condominioService; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            var condominios = _condominioService.GetAll();
            var vm = _mapper.Map<IEnumerable<CondominioViewModel>>(condominios);
            return Ok(vm);
        }

        [HttpPut]
        public IActionResult Put(CondominioViewModel vm)
        {
            var model = _mapper.Map<Condominio>(vm);

            try
            {
                _condominioService.Update(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}