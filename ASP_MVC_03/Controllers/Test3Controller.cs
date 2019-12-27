using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_03.Models;

namespace ASP_MVC_03.Controllers
{
    public class Test3Controller : Controller
    {
        // GET: Test3
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult View2()
        {
            ViewBag.Names = new List<string> { "Some", "List", "Of", "Strings" };
            return View("TestView");
        }

        public ActionResult View3()
        {
            var t1 = new Test() { TestId=1, TestName="TestName" };
            var t2 = new Test() { TestId=2, TestName="TestName2" };
            var testItems = new List<Test>() { t1, t2 };
            return View(testItems);
        }
    }
}