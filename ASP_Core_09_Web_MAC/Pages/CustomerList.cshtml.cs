using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Core_09_Web_MAC.Models;

namespace ASP_Core_09_Web_MAC.Pages
{
    public class CustomerListModel : PageModel
    {

        public List<Customer> customers = new List<Customer>();
        private Northwind db;

        public CustomerListModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Customers Page";
            customers = db.Customers.ToList();
        }



    }
}
