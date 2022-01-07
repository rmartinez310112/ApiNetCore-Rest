using ApiTrueHome.Aplicacion;
using ApiTrueHome.Modelo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrueHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data) {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Property>>> GetPropertys()
        {
            return await _mediator.Send(new ConsultaProperty.PropertyList());
        }
    }
}
