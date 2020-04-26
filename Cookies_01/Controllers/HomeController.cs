using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cookies_01.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
using Newtonsoft.Json;


namespace Cookies_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Did not fully finish this lesson
            // For javascript cookies can check out my jsfiddle
            Response.Cookies.Append("MyCookie", "value1");
            var cookieValue = Request.Cookies["MyCookie"];
            var cookieValueNull = Request.Cookies["nonexistent"]; //return null
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("MyCookie", "value1", cookieOptions);
            Debug.WriteLine(JsonConvert.SerializeObject(Response.Cookies));
            Debug.WriteLine($"\ncookieValue is {cookieValue}");
            var cookieExpires = Request.Cookies["MyCookie"].ToString();
            

            Console.WriteLine($"\ncookieExpires is {cookieExpires}");


            
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
