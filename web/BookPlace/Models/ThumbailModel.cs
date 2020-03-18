using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlace.Models
{
    public class ThumbailModel
    {
        public string Author { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }

    }
}