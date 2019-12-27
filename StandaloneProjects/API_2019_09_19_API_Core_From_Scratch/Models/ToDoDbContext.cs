using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API_2019_09_19_API_Core_From_Scratch.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<ToDo> ToDoes { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlite("DataSource=DefaultDatabase");
        //}
        public ToDoDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDo>(item => {
                item.Property(i => i.ToDoId).IsRequired();
            });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 1, ToDoItem = "Test", ToDoDone = false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 2, ToDoItem = "DoThis", ToDoDone = false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 3, ToDoItem = "Do That", ToDoDone = true });
        }



    }
}
