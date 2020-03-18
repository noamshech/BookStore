using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlace.Models
{
    public class View
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
    }
}