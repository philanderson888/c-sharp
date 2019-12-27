using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVC_Core_Movie_02.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
