using ApiTrueHome.Modelo;
using ApiTrueHome.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion
{
    public class NuevoActivity
    {
        public class Ejecuta : IRequest
        {
            public DateTime schedule { get; set; }
            public string title { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string status { get; set; }
            public int property_id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoProperty _contexto;
            public Manejador(ContextoProperty contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var property = await _contexto.Property.FindAsync(request.property_id);
                var activities = await _contexto.Activity.Where(x => x.property_id == request.property_id).ToListAsync();

                DateTime scheduleValue = request.schedule;
                DateTime scheduleValueMax = scheduleValue.AddHours(1);
                int validaFechas = 0;

                if (property == null)
                {
                    throw new Exception("No existe propiedad");
                }

                if (property.status != "Inactive")
                {
                    foreach (var item in activities)
                    {
                        if (item.schedule >= scheduleValue && item.schedule <= scheduleValueMax)
                        {
                            validaFechas = 1;
                        }
                    }

                    if (validaFechas != 1)
                    {
                        var activity = new Activity
                        {
                            property_id = request.property_id,
                            schedule = request.schedule,
                            title = request.title,
                            created_at = request.created_at,
                            updated_at = request.updated_at,
                            status = request.status
                        };

                        _contexto.Activity.Add(activity);
                        var valor = await _contexto.SaveChangesAsync();

                        if (valor > 0)
                        {
                            return Unit.Value;
                        }

                        throw new Exception("No se pudo insertar la actividad");
                    }
                    else
                    {
                        throw new Exception("Ya existe una actividad en ese horario para esa propiedad");
                    }
                }
                else
                {
                    throw new Exception("La propiedad esta cancelada");
                }
            }
        }

    }
}
