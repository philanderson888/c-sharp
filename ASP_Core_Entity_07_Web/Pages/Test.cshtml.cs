using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Core_Entity_07_Web
{
    public class TestModel : PageModel
    {
        public static List<Customer> customers = new List<Customer>();

        public void OnGet()
        {
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();
            }
        }
    }
}