using AutoMapper;
using DDonah.AthosDesafio.Domain;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.WebApi.Controllers.Base;
using DDonah.AthosDesafio.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var condominio = _condominioService.Get(id);
            if (condominio == null)
            {
                return NotFound();
            }
            else
            {
                var viewmodel = _mapper.Map<CondominioViewModel>(condominio);
                return Ok(viewmodel);
            }
        }

        [HttpPost]
        public IActionResult Post(CondominioViewModel vm)
        {
            var model = _mapper.Map<Condominio>(vm);

            try
            {
                _condominioService.Save(model);
                vm = _mapper.Map<CondominioViewModel>(model);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_condominioService.Exists(x => x.Id == id))
            {
                return NotFound();
            }
            else
            {
                _condominioService.Delete(id);
                return NoContent();
            }
        }
    }
}