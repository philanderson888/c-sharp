using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EFCore_11_Create_Database
{
    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = UserMigrationDatabase");
            //builder.UseSqlite("Data Source = UsersAndCategories.db");
        }
    }
}
