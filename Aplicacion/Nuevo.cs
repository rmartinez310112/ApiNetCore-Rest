using ApiTrueHome.Modelo;
using ApiTrueHome.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTrueHome.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest {
            public string title { get; set; }
            public string address { get; set; }
            public string description { get; set; }
            public DateTime create_at { get; set; }
            public DateTime? updated_at { get; set; }
            public DateTime? disabled_at { get; set; }
            public string status { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoProperty _contexto;
            public Manejador(ContextoProperty contexto) {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var property = new Property
                { 
                title =request.title,
                address= request.address,
                description = request.description,
                create_at = request.create_at,
                updated_at = request.updated_at,
                disabled_at = request.disabled_at,
                status = request.status,
                propertyGuid = Convert.ToString(Guid.NewGuid())
                };

                _contexto.Property.Add(property);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el valor de Property");
            }
        }
    }
}
