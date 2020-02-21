using EFCore_12_Samurai_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore_11_Samurai_01
{
    class Program
    {
        static void Main(string[] args)
        {

            List<FirstModel> firstmodelitems = new List<FirstModel>();
            List<SecondModel> secondmodelitems = new List<SecondModel>();
            List<FirstModelSecondModelJoiningTable> joiningtable = new List<FirstModelSecondModelJoiningTable>();
            List<User> users = new List<User>();
            List<Company> companies = new List<Company>();
            List<Category> categories = new List<Category>();

            //var seconditem = new SecondModel { SecondModelName = "another name" };
            //var firstitem = new FirstModel { FirstModelId=10, FirstModelName = "some name", JoiningTable = new  };



            using (var db = new UserDatabaseContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //db.SecondModels.Add(seconditem);
                //db.FirstModels.Add(firstitem);

                //var joinitem = new FirstModelSecondModelJoiningTable
                //{
                //    FirstModelId = firstitem.FirstModelId,
                //    FirstModel = firstitem,
                //    SecondModelId = seconditem.SecondModelId,
                //    SecondModel = seconditem
                //};


                //db.JoiningTable.Add(joinitem);
                //db.SaveChanges();


                firstmodelitems = db.FirstModels.ToList();
                secondmodelitems = db.SecondModels.ToList();
                joiningtable = db.JoiningTable.ToList();
                users = db.Users
                    .Include(user => user.Company)
                    .Include(user => user.Category)
                    .ToList();
                // categories = db.Categories.ToList();
                // co#mpanies = db.Companies.ToList();
            }

            firstmodelitems.ForEach(item => Console.WriteLine($"{item.FirstModelId,-10}{item.FirstModelName}"));
            secondmodelitems.ForEach(item => Console.WriteLine($"{item.SecondModelId,-10}{item.SecondModelName}"));
            joiningtable.ForEach(item => Console.WriteLine($"{item.FirstModelId,-10}{item.SecondModelId}"));
            users.ForEach(user => Console.WriteLine($"{user.UserId,-10}{user.UserName,-20}{user.Category.CategoryName,-20}" +
                $"{user.Company.CompanyName,-20}{user.UserName}"));

        }
    }
}




