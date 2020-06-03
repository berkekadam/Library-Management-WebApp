using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CME4414.Models;

namespace CME4414.Controllers
{
    public class UserController : Controller
    {
        CME4414Entities db = new CME4414Entities();
        [Authorize]
        // GET: User
        public ActionResult Index()
        {
            var userlist = db.User.ToList();
            return View(userlist);
        }

        [HttpGet]
        public ActionResult newUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult newUser(User p1)
        {
            if (!ModelState.IsValid)
            {
                return View("newUser");
            }
            db.User.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var deletion = db.User.Find(ID);
            db.User.Remove(deletion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}