using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPEntityCore_05_Movie.Models;
using SPEntityCore_05_Movie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPEntityCore_05_Movie.Pages.Models
{
    public class IndexModel2 : PageModel
    {
        private readonly ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext _context;

        public IndexModel2(ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync2()
        {
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
