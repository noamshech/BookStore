using BookPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlace.ViewModel
{
    public class ThumbnailBoxViewModel
    {
        public IEnumerable<ThumbailModel> Thumbnails { get; set; }
    }
}