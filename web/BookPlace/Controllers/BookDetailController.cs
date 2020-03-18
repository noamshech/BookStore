using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookPlace.Models;
using Microsoft.AspNet.Identity;
using BookPlace.Utility;
using BookPlace.ViewModel;

namespace BookPlace.Controllers
{
    public class BookDetailController : Controller
    {
        private ApplicationDbContext db;

        public BookDetailController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: BookDetail
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);

            var bookModel = db.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            BookDetailViewModel model = new BookDetailViewModel
            {
                BookId = bookModel.Id,
                Author = bookModel.Author,
                Avaibility = bookModel.Avaibility,
                DataAdded = bookModel.PublicationData,
                Description = bookModel.Description,
                Genre = db.Genres.FirstOrDefault(g => g.Id.Equals(bookModel.GenreId)),
                GenreId = bookModel.GenreId,
                ImageUrl = bookModel.ImageUrl,
                Pages = bookModel.Pages,
                Price = bookModel.Price,
                PublicationData = bookModel.PublicationData,
                Title = bookModel.Title,
                UserId = userid

            };

            if (Request.IsAuthenticated)
            {
                ApplicationUser currentUser = db.Users.Find(userid);
                View view = new View { Book = bookModel, User = currentUser };
                db.Views.Add(view);
                db.SaveChanges();
            }
                return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}