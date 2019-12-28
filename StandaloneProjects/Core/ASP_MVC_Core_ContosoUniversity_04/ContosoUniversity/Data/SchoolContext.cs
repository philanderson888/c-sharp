using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoUniversity.Models.Course> Course { get; set; }

        public DbSet<ContosoUniversity.Models.Enrollment> Enrollment { get; set; }

        public DbSet<ContosoUniversity.Models.Room> Room { get; set; }
    }
}
