using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore_10
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
                var user1 = new User() { UserName = "Fred", CategoryId = 1 };
                var user2 = new User() { UserName = "Bob", CategoryId = 2 };
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







    
}
