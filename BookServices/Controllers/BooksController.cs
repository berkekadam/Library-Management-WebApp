using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BookDataAccess;

namespace BookServices.Controllers
{
    public class BooksController : ApiController
    {
        BookDetailsEntities db = new BookDetailsEntities();
        public BooksController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Book> Get()
        {
            using (db)
            {
                return db.Book.ToList();
            }
        }

        public Book Get(int ID)
        {
            using (db)
            {
                return db.Book.FirstOrDefault(e => e.BookID == ID);
            }
        }
    }
}
