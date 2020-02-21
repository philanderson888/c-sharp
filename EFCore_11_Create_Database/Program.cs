using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_11_Create_Database
{



    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UserDatabaseContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                //var category1 = new Category() { CategoryName = "Admin" };
                //var category2 = new Category() { CategoryName = "User" };
                //var category3 = new Category() { CategoryName = "Personal" };
                var company1 = new Company() { CompanyName = "Sparta" };
                var company2 = new Company() { CompanyName = "Three" };
                var company3 = new Company() { CompanyName = "BBC" };
                var user1 = new User() { UserName = "Fred", CategoryId = 1, CompanyId = 1 };
                var user2 = new User() { UserName = "Bob", CategoryId = 2, CompanyId = 2 };
                var user3 = new User() { UserName = "Tim", CategoryId = 3, CompanyId = 3 };
               // db.Categories.AddRange(category1, category2, category3);
                db.Companies.AddRange(company1, company2, company3);
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                //  var categories = db.Categories.ToList();
                // var companies = db.Companies.ToList();

                var users = db.Users.Include(u => u.Company).Include(u => u.Category).ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.UserId,-10} {user.UserName,-20}{user.Category.CategoryName,-20}" +
                        $"{user.Company.CompanyName}");
                }
            }
        }
    }



    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

}




