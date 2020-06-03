using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CME4414.Models;

namespace CME4414.Controllers
{
    public class BorrowController : Controller
    {
        CME4414Entities db = new CME4414Entities();
        // GET: Borrow
        public ActionResult Index()
        {
            var borrowlist = db.Borrow.ToList();
            return View(borrowlist);
        }

        public ActionResult newBorrow()
        {
            List<SelectListItem> variablesBook = (from i in db.Book.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.BookName,
                                                        Value = i.BookID.ToString()
                                                    }).ToList();
            List<SelectListItem> variablesUser = (from i in db.User.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Name,
                                                      Value = i.UserID.ToString()
                                                  }).ToList();
            
            ViewBag.varBook = variablesBook;
            ViewBag.varUsr = variablesUser;
            return View();
        }

        [HttpPost]
        public ActionResult newBorrow(Borrow p1)
        {
            var book = db.Book.Where(m => m.BookID == p1.Book.BookID).FirstOrDefault();
            var usr = db.User.Where(m => m.UserID == p1.User.UserID).FirstOrDefault();
            p1.Book = book;
            p1.User = usr;
            db.Borrow.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}