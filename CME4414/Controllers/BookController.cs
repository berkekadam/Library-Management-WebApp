using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CME4414.Models;
using PagedList;
using PagedList.Mvc;

namespace CME4414.Controllers
{
    public class BookController : Controller
    {
        CME4414Entities db = new CME4414Entities();
        // GET: Book
        public ActionResult Index()
        {
             var booklist = db.Book.ToList();
            return View(booklist);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult newBook()
        {
            List<SelectListItem> variablesWriter = (from i in db.Writer.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.WriterName,
                                                        Value = i.WriterID.ToString()
                                                    }).ToList();
            List<SelectListItem> variablesPublisher = (from i in db.Publisher.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = i.PublisherName,
                                                           Value = i.PublisherID.ToString()
                                                       }).ToList();
            List<SelectListItem> variablesUser = (from i in db.User.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = i.Name,
                                                           Value = i.UserID.ToString()
                                                       }).ToList();
            ViewBag.varWri = variablesWriter;
            ViewBag.varPub = variablesPublisher;
            ViewBag.varUsr = variablesUser;
            return View();
        }

        [HttpPost]
        public ActionResult newBook(Book p1)
        {
            var wri = db.Writer.Where(m => m.WriterID == p1.Writer.WriterID).FirstOrDefault();
            var pub = db.Publisher.Where(m => m.PublisherID == p1.Publisher.PublisherID).FirstOrDefault();
            var usr = db.User.Where(m => m.UserID == p1.User.UserID).FirstOrDefault();
            p1.Writer = wri;
            p1.Publisher = pub;
            p1.User = usr;
            db.Book.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var deletion = db.Book.Find(ID);
            db.Book.Remove(deletion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getBook(int ID)
        {
            var book = db.Book.Find(ID);

            List<SelectListItem> variablesWriter = (from i in db.Writer.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.WriterName,
                                                        Value = i.WriterID.ToString()
                                                    }).ToList();
            List<SelectListItem> variablesPublisher = (from i in db.Publisher.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = i.PublisherName,
                                                           Value = i.PublisherID.ToString()
                                                       }).ToList();
            List<SelectListItem> variablesUser = (from i in db.User.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Name,
                                                      Value = i.UserID.ToString()
                                                  }).ToList();
            ViewBag.varWri = variablesWriter;
            ViewBag.varPub = variablesPublisher;
            ViewBag.varUsr = variablesUser;
            return View("getBook", book);
        }

        public ActionResult Update(Book p1)
        {
            var book = db.Book.Find(p1.BookID);
            book.BookName = p1.BookName;
            book.Genre = p1.Genre;
            book.ReleaseDate = p1.ReleaseDate;
            book.PageNumber = p1.PageNumber;
            book.Description = p1.Description;
            book.Img_Link = p1.Img_Link;
            var wri = db.Writer.Where(m => m.WriterID == p1.Writer.WriterID).FirstOrDefault();
            var pub = db.Publisher.Where(m => m.PublisherID == p1.Publisher.PublisherID).FirstOrDefault();
            var usr = db.User.Where(m => m.UserID == p1.User.UserID).FirstOrDefault();
            book.WriterID = wri.WriterID;
            book.PublisherID = pub.PublisherID;
            book.DonatorID = usr.UserID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}