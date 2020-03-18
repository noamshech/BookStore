using BookPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlace.Extensions
{
    public static class ThumbnailExtensions
    {
        public static IEnumerable<ThumbailModel> GetBookThumbnail(this List<ThumbailModel> thumbnails, ApplicationDbContext db = null, string title = null, string author = null, string discription = null)
        { //we get the search query from the HomeController
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails = (from b in db.Books
                              select new ThumbailModel
                              {
                                  Author = b.Author,
                                  BookId = b.Id,
                                  Title = b.Title,
                                  Description = b.Description,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/BookDetail/Index/" + b.Id, //goes to BookDeatil view
                              }).ToList();

                if (title != null && discription != null && author != null)
                {

                    return thumbnails.Where(t => t.Title.ToLower().Contains(title.ToLower())).
                                       Where(t => t.Description.ToLower().Contains(discription.ToLower())).
                                       Where(t => t.Author.ToLower().Contains(author.ToLower())).
                                        OrderBy(t => t.Title);
                }
                if (title == null && discription != null && author != null)
                {

                    return thumbnails.Where(t => t.Description.ToLower().Contains(discription.ToLower())).
                                       Where(t => t.Author.ToLower().Contains(author.ToLower())).
                                        OrderBy(t => t.Title);
                }
                if (title == null && discription == null && author != null)
                {

                    return thumbnails.Where(t => t.Author.ToLower().Contains(author.ToLower())).
                                        OrderBy(t => t.Title);
                }
                if (title != null && discription == null && author != null)
                {

                    return thumbnails.Where(t => t.Title.ToLower().Contains(title.ToLower())).
                                       Where(t => t.Author.ToLower().Contains(author.ToLower())).
                                        OrderBy(t => t.Title);
                }
                if (title != null && discription == null && author == null)
                {

                    return thumbnails.Where(t => t.Title.ToLower().Contains(title.ToLower())).

                                        OrderBy(t => t.Title);
                }
                if (title == null && discription != null && author == null)
                {

                    return thumbnails.Where(t => t.Description.ToLower().Contains(discription.ToLower())).
                                           OrderBy(t => t.Title);
                }
            }
            catch (Exception ex)
            {

            }
            return thumbnails.OrderBy(t => t.Title);

        }
    }
}