using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_15_MySQL.Models
{
    public class BookmarkDbContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BookmarkDbContext(DbContextOptions<BookmarkDbContext> options) : base(options) { }
    }
}
