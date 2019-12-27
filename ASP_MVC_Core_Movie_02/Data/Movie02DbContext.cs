using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_Core_Movie_02.Models
{
    public class Movie02DbContext : DbContext
    {
        public Movie02DbContext (DbContextOptions<Movie02DbContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_MVC_Core_Movie_02.Models.Movie> Movie { get; set; }
    }
}
