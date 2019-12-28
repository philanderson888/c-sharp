using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_Core_Movie_05.Models
{
    public class Movie05DbContext : DbContext
    {
        public Movie05DbContext (DbContextOptions<Movie05DbContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_MVC_Core_Movie_05.Models.Movie> Movie { get; set; }
    }
}
