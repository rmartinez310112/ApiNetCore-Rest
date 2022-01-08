using ApiTrueHome.Modelo;
using ApiTrueHome.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion.Activities
{
    public class Consultar
    {
        public class ActivitiesList : IRequest<List<ActivityNew>>{}

        public class Manejador : IRequestHandler<ActivitiesList, List<ActivityNew>>
        {
            public readonly ContextoProperty _contexto;
            public Manejador(ContextoProperty contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<ActivityNew>> Handle(ActivitiesList request, CancellationToken cancellationToken)
            {
                DateTime fechaIncial = DateTime.Now.AddDays(-3);
                DateTime fechaFinal = DateTime.Now.AddDays(14);
                var activities = await _contexto.Activity.Where(x => x.schedule >= fechaIncial && x.schedule <= fechaFinal).ToListAsync();
                List<ActivityNew> list = new List<ActivityNew>();
                foreach (var i in activities)
                {
                    ActivityNew act = new ActivityNew() {
                        activity_id = i.activity_id,
                        property_id = i.property_id,
                        schedule = i.schedule,
                        title = i.title,
                        created_at = i.created_at,
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
