using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace ASP_Core_09_Web_MAC.Models
{

    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
 

        public Northwind() { }

        public Northwind(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../data/Northwind.db");

       
          //  optionsBuilder.UseSqlite($"Filename={path}");


            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }


    }
}
