using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Entity_08_Web.Models;

namespace ASP_Core_Entity_08_Web.Pages
{
    public class AboutModel : PageModel
    {

        public IEnumerable<string> Customers { get; set; }

        public List<Customer> customers = new List<Customer>();
        private Northwind db;

        public AboutModel (Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Customers Page";

            //    Customers = new[] { "first", "second", "third" };
            Customers = db.Customers.Select(c => c.ContactName).ToArray();
            customers = db.Customers.ToList();
        }
    }
}
