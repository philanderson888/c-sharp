using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Entity_11_Web.Models;

namespace ASP_Core_Entity_11_Web.Controllers
{
    public class DetailsModel : PageModel
    {
        private readonly ASP_Core_Entity_11_Web.Models.Northwind _context;

        public DetailsModel(ASP_Core_Entity_11_Web.Models.Northwind context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
