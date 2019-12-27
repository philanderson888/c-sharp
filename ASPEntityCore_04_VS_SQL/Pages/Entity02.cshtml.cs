using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPCoreEntity_03_Data;

namespace ASPEntityCore_04_VS_SQL.Pages
{
    public class Entity02Model : PageModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Customer> CustomerSubset { get; set; }
        public IEnumerable<Customer> CustomersByCity { get; set; }
        public string CustomerCity { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Customer List";
            Customers = new List<Customer>();
            CustomerSubset = new List<Customer>();
            CustomerCity = "Berlin";
            using (var db = new Northwind())
            {
                Customers = db.Customers.ToList();
                CustomerSubset = db.Customers.Where(c => c.City == CustomerCity).ToList<Customer>();
                //CustomersByCity = (
                //    from c in db.Customers
                //    group c by c.City into cities
                //    select new { })
                //    .ToList<Customer>();
            }
        }
    }


}