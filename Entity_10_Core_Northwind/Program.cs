using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entity_10_Core_Northwind
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Product> products2;

            using (var db = new Northwind()){
                products = db.Products.ToList<Product>();
            }
            products.ForEach(p => {
                Console.WriteLine(p.ProductName);
            });

            // We can also use LINQ Include Categories
            using(var db = new Northwind())
            {
                products2 = db.Products.Include("Category").ToList();
            }

            products2.ForEach(p => {
                Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-40}" +
                    $"{p.CategoryID,-7}{p.Category.CategoryName,-20}{p.Category.Description,-40}");

            });



        }
    }


    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }



    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../data/Northwind.db");
            Console.WriteLine(System.Environment.CurrentDirectory);

            // windows path
            string path = "../../../../data/Northwind.db";

            // use SQLite
            optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            // filter out discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }

    }



}
