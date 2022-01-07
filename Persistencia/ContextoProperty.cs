using ApiTrueHome.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrueHome.Persistencia
{
    public class ContextoProperty : DbContext
    {
        public ContextoProperty(DbContextOptions<ContextoProperty> options) : base(options) { }

        public DbSet<Property> Property { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Survey> Survey { get; set; }
    }
}
