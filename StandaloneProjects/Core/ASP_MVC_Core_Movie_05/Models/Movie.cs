using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Core_Movie_05.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
