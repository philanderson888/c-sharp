using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPEntityCore_05_Movie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        // note : setting this to date means 
        // the user is not required to enter time information
        // also when displaying this field, 
        // only date information is supplied
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
