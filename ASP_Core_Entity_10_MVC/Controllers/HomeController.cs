using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Core_Entity_10_MVC.Models;

namespace ASP_Core_Entity_10_MVC.Controllers
{
    public class HomeController : Controller
    {

        private Northwind db;

        public HomeController(Northwind injectedContext){
            db = injectedContext;
        }

        public IActionResult Index()
        {

            var model = new HomeIndexViewModel()
            {
                customers = db.Customers.ToList()
            };
            return View(model);
        }

        public IActionResult CustomerDetail(string id){

            var model = db.Customers.SingleOrDefault(c => c.CustomerID == id);

            return View(model);

        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
