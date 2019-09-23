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
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IMapper mapper, IUsuarioService usuarioService) : base(mapper)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _usuarioService.GetAll();
            var vmList = _mapper.Map<IEnumerable<UsuarioViewModel>>(list);
            return Ok(vmList);
        }

        [HttpGet]
        [Route("sindico")]
        public IActionResult GetSindico()
        {
            var responsaveisModel = _usuarioService.GetSindico();
            var viewModel = _mapper.Map<IEnumerable<UsuarioViewModel>>(responsaveisModel);
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("zelador")]
        public IActionResult GetZelador()
        {
            var responsaveisModel = _usuarioService.GetZelador();
            var viewModel = _mapper.Map<IEnumerable<UsuarioViewModel>>(responsaveisModel);
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("morador")]
        public IActionResult GetMorador()
        {
            var responsaveisModel = _usuarioService.GetMorador();
            var viewModel = _mapper.Map<IEnumerable<UsuarioViewModel>>(responsaveisModel);
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var model = _usuarioService.Get(id);
            var viewModel = _mapper.Map<UsuarioViewModel>(model);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post(UsuarioViewModel viewModel)
        {
            var model = _mapper.Map<Usuario>(viewModel);

            try
            {
                _usuarioService.Save(model);
                viewModel = _mapper.Map<UsuarioViewModel>(model);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel vm)
        {
            var model = _mapper.Map<Usuario>(vm);

            try
            {
                _usuarioService.Update(model);
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
            if (!_usuarioService.Exists(x => x.Id == id))
            {
                return NotFound();
            }

            try
            {
                _usuarioService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}