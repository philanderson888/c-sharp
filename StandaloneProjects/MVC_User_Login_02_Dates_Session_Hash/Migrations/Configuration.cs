namespace MVC_User_Login.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC_User_Login.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_User_Login.Models.UserLoginModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_User_Login.Models.UserLoginModel context)
        {

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(x=>x.UserId,
                new User() { UserId = 1, UserName = "bob@abc.com", Password = Environment.GetEnvironmentVariable("PhilsSecretPassword") },
                new User() { UserId = 2, UserName = "tom@abc.com", Password = Environment.GetEnvironmentVariable("PhilsSecretPassword") },
                new User() { UserId = 3, UserName = "rob@abc.com", Password = Environment.GetEnvironmentVariable("PhilsSecretPassword") }    
                );
        }
    }
}
