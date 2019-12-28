using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_2019_09_01_Movie_Database.Models;

namespace MVC_2019_09_01_Movie_Database.Controllers
{
    public class Movies2Controller : Controller
    {
        public List<Movie> movies;
        MovieDbContext db;
        public Movies2Controller(MovieDbContext db)
        {
            db = db;
        }
        public IActionResult Index()
        {
            movies = db.Movies.ToList();
            return View(movies);
        }
    }
}