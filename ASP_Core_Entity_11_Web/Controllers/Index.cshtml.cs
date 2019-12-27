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
    public class IndexModel : PageModel
    {
        private readonly ASP_Core_Entity_11_Web.Models.Northwind _context;

        public IndexModel(ASP_Core_Entity_11_Web.Models.Northwind context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
