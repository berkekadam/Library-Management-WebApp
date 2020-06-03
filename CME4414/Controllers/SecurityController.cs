using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CME4414.Models;

namespace CME4414.Controllers
{
    public class SecurityController : Controller
    {
        CME4414Entities db = new CME4414Entities();

        public object DefaultAuthenticationTypes { get; private set; }

        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var check = db.User.FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
            if(check != null)
            {
                FormsAuthentication.SetAuthCookie(check.Email, false);
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User p1)
        {
            p1.Role = "User";
            db.User.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}