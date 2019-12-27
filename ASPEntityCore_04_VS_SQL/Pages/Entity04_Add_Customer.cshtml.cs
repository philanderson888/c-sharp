using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPCoreEntity_03_Data;

namespace ASPEntityCore_04_VS_SQL.Pages
{
    public class Entity04_Add_CustomerModel : PageModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Northwind db;
        [BindProperty]
        public Customer customer { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToPage("/Entity04_Add_Customer");
            }
            return Page();
        }

        public Entity04_Add_CustomerModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Add New Customer";
            Customers = db.Customers.Select(c => c).ToList<Customer>();
        }
    }
}