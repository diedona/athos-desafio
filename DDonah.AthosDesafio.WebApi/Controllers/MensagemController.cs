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
    public class MensagemController : BaseApiController
    {
        private readonly IMensagemService _mensagemService;
        private readonly IAssuntoService _assuntoService;

        public MensagemController(IMapper mapper, IMensagemService mensagemService, IAssuntoService assuntoService) : base(mapper)
        {
            _mensagemService = mensagemService;
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listModel = _mensagemService.GetAll();
            var listViewModel = _mapper.Map<IEnumerable<MensagemViewModel>>(listModel);
            return Ok(listViewModel);
        }

        [HttpGet]
        [Route("assunto")]
        public IActionResult GetAssuntos()
        {
            var listModel = _assuntoService.GetAll();
            var listViewModel = _mapper.Map<IEnumerable<AssuntoViewModel>>(listModel);
            return Ok(listViewModel);
        }

        [HttpPost]
        public IActionResult Post(MensagemViewModel viewModel)
        {
            var model = _mapper.Map<Mensagem>(viewModel);

            try
            {
                _mensagemService.Save(model);
                viewModel = _mapper.Map<MensagemViewModel>(model);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}