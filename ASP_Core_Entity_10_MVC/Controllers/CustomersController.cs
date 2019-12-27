using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Core_Entity_10_MVC.Controllers
{
    public class CustomersController : Controller
    {

        private Northwind db;
        List<Customer> customers;

        public CustomersController(Northwind injectedContext)
        {
            db = injectedContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            

            var model = new ASP_Core_Entity_10_MVC.Models.HomeIndexViewModel()
            {
                customers = db.Customers.ToList()
            };
            return View(model);


        }
    }
}
