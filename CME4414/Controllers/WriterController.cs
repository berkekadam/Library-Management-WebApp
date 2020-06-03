using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CME4414.Models;

namespace CME4414.Controllers
{
    public class WriterController : Controller
    {
        CME4414Entities db = new CME4414Entities();
        [Authorize]
        // GET: Writer
        public ActionResult Index()
        {
            var writerlist = db.Writer.ToList();
            return View(writerlist);
        }

        [HttpGet]
        public ActionResult newWriter()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult newWriter(Writer p1)
        {
            if (!ModelState.IsValid)
            {
                return View("newWriter");
            }
            db.Writer.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var deletion = db.Writer.Find(ID);
            db.Writer.Remove(deletion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getWriter(int ID)
        {
            var writer = db.Writer.Find(ID);
            return View("getWriter", writer);
        }

        public ActionResult Update(Writer p1)
        {
            var writer = db.Writer.Find(p1.WriterID);
            writer.WriterName = p1.WriterName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}