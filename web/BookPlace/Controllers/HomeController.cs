using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookPlace.ViewModel;
using BookPlace.Extensions;
using BookPlace.Models;
using Microsoft.AspNet.Identity;

namespace BookPlace.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string title = null, string author = null, string discription = null)
        {
            var thumbnails = new List<ThumbailModel>().GetBookThumbnail(ApplicationDbContext.Create(), title, author, discription);
            //^^getting the create method in Book Create controller 
            var count = thumbnails.Count() / 4;

            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }

            if (Request.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var query = db.Views.Where(x => x.User.Id == userid).GroupBy(x => x.Book.GenreId).Select(
                    g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });

                List<Book> list = new List<Book>();
                foreach(var item in query.ToList().OrderByDescending(x => x.Key).Take(3))
                {
                    Console.WriteLine("this is my list" + item);
                    list.Add(db.Books.Where(x => x.Genre.Id.Equals(item.Key)).First());
                }
               

                ViewBag.Suggestions = list;
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}