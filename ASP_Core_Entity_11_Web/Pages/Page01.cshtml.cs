using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Core_Entity_11_Web.Models;

namespace ASP_Core_Entity_11_Web.Pages
{
    public class Page01Model : PageModel
    {

        public string Property01 { get; set; } = "default value";

        public List<String> items = new List<string>();

        public List<Customer> customers;
        public void OnGet()
        {
            var d = DateTime.Now;
            d.AddDays(2);
            Property01 = d.ToShortDateString();

            items.Add("One");
            items.Add("Two");

            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();
            }
        }
    }
}