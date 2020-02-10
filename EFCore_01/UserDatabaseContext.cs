using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCore_10
{
    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = UserDatabase01");
            //builder.UseSqlite("Data Source = UsersAndCategories.db");
        }
    }
}
