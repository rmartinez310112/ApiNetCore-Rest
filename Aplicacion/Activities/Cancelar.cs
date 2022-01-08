using ApiTrueHome.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion.Activities
{
    public class Cancelar
    {
        public class Ejecuta : IRequest
        {
            public int activity_id { get; set; }
            public string status { get; set; }
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

                activity.status = request.status;
                var resultado = await _contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo cancelar la actividad");
            }
        }
    }
}
