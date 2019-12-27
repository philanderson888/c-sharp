using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreEntity_03_Data
{
    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public Northwind() { }

        public Northwind(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Customer>()
            //    .Property(customer => customer.ContactName)
            //    .IsRequired()
            //    .HasMaxLength(30);
            //modelBuilder.Entity<Customer>()
            //    .Property(customer => customer.CustomerID)
            //    .IsRequired()
            //    .HasMaxLength(5);
            //modelBuilder.Entity<Customer>()
            //    .Property(customer => customer.CompanyName)
            //    .IsRequired()
            //    .HasMaxLength(40);
        }


    }
}
