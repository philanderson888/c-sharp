using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_2019_09_01_Movie_Database.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
                    : base(options)
        {

        }
        public DbSet<Movie> Movies {get;set;}
    }
}
