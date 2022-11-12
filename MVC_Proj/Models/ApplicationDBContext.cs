using Microsoft.EntityFrameworkCore;
using MVC_Proj.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Proj.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
        }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Persons> Persons { get; set; }

    }
}
