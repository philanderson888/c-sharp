using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreEntity_03_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPEntityCore_04_VS_SQL.Pages
{
    public class Entity03Model : PageModel
    {
        public IEnumerable<string> Customers { get; set; }
        private Northwind db;

        public Entity03Model(Northwind injectedContext)
        {
          db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Customers Page";
        
            //    Customers = new[] { "first", "second", "third" };
            Customers = db.Customers.Select(c => c.ContactName).ToArray();
        }
    }
}