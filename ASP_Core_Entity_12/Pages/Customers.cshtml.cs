using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Core_Entity_12.Models;

namespace ASP_Core_Entity_12.Pages
{
    public class CustomersModel : PageModel
    {
        public List<Customer> customers = new List<Customer>();

        public void OnGet()
        {
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();
            }
        }
    }
}