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
    public class ConsultaProperty
    {
        public class PropertyList : IRequest<List<Property>>
        {
        }

        public class Manejador : IRequestHandler<PropertyList, List<Property>>
        {
            public readonly ContextoProperty _contexto;
            public Manejador(ContextoProperty contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<Property>> Handle(PropertyList request, CancellationToken cancellationToken)
            {
                var propertys = await _contexto.Property.ToListAsync();

                return propertys;
            }
        }
    }
}
