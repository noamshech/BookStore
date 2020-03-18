using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookPlace.Models
{
    public class Store
    {
        [Required]
        public int StoreId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public double CoordinateAlt { get; set; }
        public double CoordinateLng { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }


    }
}