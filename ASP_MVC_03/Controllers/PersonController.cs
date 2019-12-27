using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_03.Controllers
{
    public class PersonController : Controller
    {
        // GET: Form1
        public ActionResult Index()
        {
            return View();
        }

        [Route("Person/GetName")]
        public ActionResult GetName()
        {
            return View();
        }


    }
}