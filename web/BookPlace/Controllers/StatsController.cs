using BookPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookPlace.Controllers
{
    public class StatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stats
        public ActionResult Index()
        {
            var query = from book in db.Books
                        join genre in db.Genres on book.GenreId equals genre.Id into prodGroup
                        from prod in prodGroup
                        group prod by prod.Name into g
                        select new { Name = g.Key, Count = g.Count() };

            Dictionary<string, int> map = query.ToDictionary(x => x.Name, x => x.Count);
            ViewBag.Map = map;

            return View();
        }

        public string GetGraph1()
        {
            StringBuilder output = new StringBuilder();
            output.Append("price\n");

            foreach(var item in db.Books)
            {
                output.Append(item.Price + "\n");
            }

            return output.ToString();

        }
    }
}