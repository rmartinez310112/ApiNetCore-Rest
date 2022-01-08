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
                var properties = await _contexto.Property.ToListAsync();
                List<Property> list = new List<Property>();

                foreach (var i in properties)
                {
                    Property prop = new Property() { 
                    property_id = i.property_id,
                    title = i.title,
                    address = i.address
                    };
                    list.Add(prop);
                }

                return list;
            }
        }
    }
}
