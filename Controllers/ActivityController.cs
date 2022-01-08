using ApiTrueHome.Aplicacion;
using ApiTrueHome.Aplicacion.Activities;
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
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoActivity.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityNew>>> GetPropertys()
        {
            return await _mediator.Send(new Consultar.ActivitiesList());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, Edit.Ejecuta data) {
            data.activity_id = id;
            return await _mediator.Send(data);
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult<Unit>> Cancelar(int id, Cancelar.Ejecuta data)
        {
            data.activity_id = id;
            return await _mediator.Send(data);
        }

        [HttpPost("Filtrar")]
        public async Task<ActionResult<List<ActivityNew>>> filtro(ConsultarFiltro.ActivitiesList data)
        {
            return await _mediator.Send(data);
        }

    }
}
