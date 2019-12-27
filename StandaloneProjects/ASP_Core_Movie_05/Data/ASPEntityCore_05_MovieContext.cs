using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPEntityCore_05_Movie.Models;

namespace ASPEntityCore_05_Movie.Models
{
    public class ASPEntityCore_05_MovieContext : DbContext
    {
        public ASPEntityCore_05_MovieContext (DbContextOptions<ASPEntityCore_05_MovieContext> options)
            : base(options)
        {
        }

        public DbSet<SPEntityCore_05_Movie.Models.Movie> Movie { get; set; }
    }
}
