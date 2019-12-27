using System;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Movie_02.Models;

namespace ASP_Core_Movie_02.Models
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_Core_Movie_02.Models.Movie> Movie { get; set; }
    }
}