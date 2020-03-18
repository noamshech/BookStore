using BookPlace.Models;
using BookPlace.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookPlace.ViewModel
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }

        //Book Model Properties
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Range(0, 1000)]
        public int Avaibility { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? DataAdded { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [DisplayName("Publication Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime PublicationData { get; set; }
        [DisplayName("Pages")]
        public int Pages { get; set; }

        //Users Model Properties
        public string UserId { get; set; }
        public string Email { get; set; }
   
    }
}