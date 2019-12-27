using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ASP_MVC_Core_Movie_01.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Index2()
        {
            return "Some string";
        }

        public string Welcome1()
        {
            return "Welcome";
        }

        public string Welcome2(string name, int numTimes=1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name} Number is {numTimes}");
        }

        public string Welcome3(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Name : {name} ID: {ID}");
        }

        public IActionResult Welcome(string name, int numTimes=1)
        {
            ViewData["Message"] = "hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }



    }
}