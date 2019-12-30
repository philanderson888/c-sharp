using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPEntityCore_05_Movie.Models;
using SPEntityCore_05_Movie.Models;

namespace ASPEntityCore_05_Movie.Pages.Models
{
    public class DetailsModel : PageModel
    {
        private readonly ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext _context;

        public DetailsModel(ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
