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
    }
}