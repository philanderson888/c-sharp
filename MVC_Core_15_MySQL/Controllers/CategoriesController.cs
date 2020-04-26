using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Core_15_MySQL.Models;


namespace MVC_Core_15_MySQL.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BookmarkDbContext _context;

        public CategoriesController(BookmarkDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
    }
}


