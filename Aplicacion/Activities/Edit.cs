using ApiTrueHome.Modelo;
using ApiTrueHome.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion.Activities
{
    public class Edit
    {
        public class Ejecuta : IRequest 
        {
            public int activity_id { get; set; }
            public DateTime schedule { get; set; }
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
                var activity = await _contexto.Activity.FindAsync(request.activity_id);

                if (activity == null)
                {
                    throw new Exception("No existe la actividad");
                }
                else if (activity.status == "Inactive")
                {
                    throw new Exception("La actividad esta inactiva");
                }
                else
                {
                    activity.schedule = request.schedule;
                    var resultado = await _contexto.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("No se guardaron los cambios en la actividad");
                }
            }
        }

    }
}
