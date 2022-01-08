using ApiTrueHome.Modelo;
using ApiTrueHome.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion.Activities
{
    public class ConsultarFiltro
    {
        public class ActivitiesList : IRequest<List<ActivityNew>> {
            public DateTime fechaInicial { get; set; }
            
            public DateTime fechafinal { get; set; }
            public string status { get; set; }
        }

        public class Manejador : IRequestHandler<ActivitiesList, List<ActivityNew>>
        {
            public readonly ContextoProperty _contexto;
            public Manejador(ContextoProperty contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<ActivityNew>> Handle(ActivitiesList request, CancellationToken cancellationToken)
            {
               // string status = request.status == null ? "Active" : request.status;
                var activities = new List<Activity>();
                if (request.status == null)
                {
                    activities = await _contexto.Activity.Where(x => x.schedule >= request.fechaInicial && x.schedule <= request.fechafinal).ToListAsync();
                }
                else
                {
                    activities = await _contexto.Activity.Where(x => x.schedule >= request.fechaInicial && x.schedule <= request.fechafinal && x.status == request.status).ToListAsync();
                }
                
                List<ActivityNew> list = new List<ActivityNew>();
                foreach (var i in activities)
                {
                    ActivityNew act = new ActivityNew()
                    {
                        activity_id = i.activity_id,
                        property_id = i.property_id,
                        schedule = i.schedule,
                        title = i.title,
                        created_at = i.created_at,
                        updated_at = i.updated_at,
                        status = i.status,
                        condition = i.status == "Active" && i.schedule >= DateTime.Now ? "Pendiente a realizar" : i.status == "Active" && i.schedule <= DateTime.Now ? "Atrasada" : "Finalizada"
                    };
                    list.Add(act);
                }

                return list;
            }
        }
    }
}
