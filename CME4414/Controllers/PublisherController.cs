using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CME4414.Models;

namespace CME4414.Controllers
{
    public class PublisherController : Controller
    {
        CME4414Entities db = new CME4414Entities();
        // GET: Publisher
        public ActionResult Index()
        {
            var publisherlist = db.Publisher.ToList();
            return View(publisherlist);
        }

        [HttpGet]
        public ActionResult newPublisher()
        {

            return View();
        }

        [HttpPost]
        public ActionResult newPublisher(Publisher p1)
        {
            if (!ModelState.IsValid)
            {
                return View("newPublisher");
            }
            db.Publisher.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var deletion = db.Publisher.Find(ID);
            db.Publisher.Remove(deletion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getPublisher(int ID)
        {
            var publisher = db.Publisher.Find(ID);
            return View("getPublisher", publisher);
        }

        public ActionResult Update(Publisher p1)
        {
            var publisher = db.Publisher.Find(p1.PublisherID);
            publisher.PublisherName = p1.PublisherName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}