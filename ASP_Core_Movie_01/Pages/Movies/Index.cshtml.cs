using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Movie_01.Models;

namespace ASP_Core_Movie_01.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ASP_Core_Movie_01.Models.RazorPagesMovieContext _context;

        public IndexModel(ASP_Core_Movie_01.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
