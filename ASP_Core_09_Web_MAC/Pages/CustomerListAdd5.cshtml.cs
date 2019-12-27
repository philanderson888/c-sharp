using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Core_09_Web_MAC.Models;

namespace ASP_Core_Entity_09_Web_MAC.Pages
{
    public class CustomerListAdd5Model : PageModel
    {

        public IEnumerable<Customer> customers { get; set; }
        public Northwind db;
        [BindProperty]
        public Customer customer { get; set; }

        public CustomerListAdd5Model (Northwind injectedContext){
            db = injectedContext;
        }

        public void OnGet()
        {
            customers = db.Customers.OrderBy(c => c.CustomerID).ToList(); 
        }

        public IActionResult OnPost(){
            if(ModelState.IsValid){
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToPage("/CustomerListAdd5");
            }
            return Page();
        }


    }
}
