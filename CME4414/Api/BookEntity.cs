using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using BookDataAccess;

namespace ApiMessages
{
    public class BookEntity
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Genre { get; set; }
        public Nullable<int> WriterID { get; set; }
        public Nullable<int> PublisherID { get; set; }
        public string ReleaseDate { get; set; }
        public string PageNumber { get; set; }
        public string Description { get; set; }
        public string Img_Link { get; set; }
        public Nullable<int> DonatorID { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual User User { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual Borrow Borrow { get; set; }
    }
}