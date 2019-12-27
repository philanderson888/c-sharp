using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_2019_09_01_ToDo_App_With_Relationships.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string ToDoItem { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class User
    {
        public User()
        {
            ToDos = new HashSet<ToDo>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }

    public class Category
    {
        public Category()
        {
            ToDos = new HashSet<ToDo>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }

    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual  DbSet<User> Users { get; set; }
        public virtual  DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasMany(c => c.ToDos).WithOne(t => t.Category);

            builder.Entity<User>().HasMany(u => u.ToDos).WithOne(u => u.User);

            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

            builder.Entity<User>().Property(u => u.UserName).IsRequired();
        }

    }

}
