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
    public class AssuntoController : BaseApiController
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoController(IMapper mapper, IAssuntoService assuntoService) : base(mapper)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _assuntoService.GetAll();
            var vmList = _mapper.Map<IEnumerable<AssuntoViewModel>>(list);
            return Ok(vmList);
        }
    }
}