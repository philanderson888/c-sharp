using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_User_Login.Models;


namespace MVC_User_Login.Controllers
{
    public class UsersController : Controller
    {
        private UserLoginModel db = new UserLoginModel();
        public List<User> Users = new List<User>();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include ="UserId,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,Password")] UserLoginViewModel userloginviewmodel)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(usr=>usr.UserName==userloginviewmodel.UserName).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == userloginviewmodel.Password)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.UserFieldIsNull = "none";
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            return View(userloginviewmodel);
        }

    }
}