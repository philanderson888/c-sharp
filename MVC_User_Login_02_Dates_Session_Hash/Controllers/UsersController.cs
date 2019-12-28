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
        private UserSession userSession;

        // GET: Users
        public ActionResult Index()
        {
            if(this.Session["ValidateUserSession"] != null)
            {
                userSession = this.Session["ValidateUserSession"] as UserSession;
                if ((userSession.UserName != null) && (userSession.LastActiveClick.Subtract(DateTime.UtcNow).TotalMinutes <= 1)) {

                    return View(db.Users.ToList());
                }
            }
            ViewBag.MustLoginToViewUsers = true;
            return View("Login");
            
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            this.Session["ValidateUserSession"] = null;
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include ="UserId,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var userExists = (db.Users.Any(u => u.UserName == user.UserName));
                if (userExists)
                {
                    ViewBag.UserExists = true;
                    return View(user);
                }
                user.CreatedDate = DateTime.UtcNow;
                user.ModifiedDate = DateTime.UtcNow;
                user.CreatedBy = user.UserName;
                user.ModifiedBy = user.UserName;
                user.IsActive = true;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // I think this code is invalid and does not work; using a different solution
        [HttpPost]
        public JsonResult DoesUserExist(string UserName)
        {
            var usr = db.Users.Any(u => u.UserName == UserName);
            return Json(usr == false, JsonRequestBehavior.AllowGet);
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
                        var userSession = new UserSession()
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            LastActiveClick = DateTime.UtcNow
                        };
                        this.Session["ValidateUserSession"] = userSession;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.InvalidPassword = true;
                        userloginviewmodel.Password = null;
                        return View(userloginviewmodel);
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