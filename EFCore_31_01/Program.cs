using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore_31_01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UserDatabaseContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var category1 = new Category() { CategoryName = "Admin" };
                var category2 = new Category() { CategoryName = "User" };
                var category3 = new Category() { CategoryName = "Personal" };
                var user1 = new User(){ UserName = "Fred", CategoryId = 1 };
                var user2 = new User() { UserName = "Bob" , CategoryId = 2 };
                var user3 = new User() { UserName = "Tim", CategoryId = 3 };
                db.Categories.AddRange(category1, category2, category3);
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();
                var users = db.Users.ToList();
                var categories = db.Categories.ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.UserId,-10} {user.UserName,-20}{user.Category.CategoryName}");
                }
            }
        }
    }

    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = UserDatabase01");
            //builder.UseSqlite(@"Data Source = UsersAndCategories.db");
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    
}
