using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDataAccess;
using System.Net.Http;
using ApiMessages;

namespace CME4414.Controllers
{
    public class BooksController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            var books = GetFromAPI();
            return View(books);
        }

        private List<BookEntity> GetFromAPI()
        {
            try
            {
                var resultList = new List<BookEntity>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44361/api/Books").ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<BookEntity>>();
                        readResult.Wait();
                        resultList = readResult.Result;
                    }
                });
                getDataTask.Wait();
                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}