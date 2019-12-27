using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPEntityCore_05_Movie.Models;
using SPEntityCore_05_Movie.Models;

namespace ASPEntityCore_05_Movie.Pages.Models
{
    public class CreateModel : PageModel
    {
        private readonly ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext _context;

        public CreateModel(ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}