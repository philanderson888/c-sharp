using System;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Entity_09_LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
          QueryingCategories();
        }
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("\n\nTranslating To XML\n");
                var ProductsToXML = db.Products.Take(3);
                var xml = new XElement("products",
                    from p in ProductsToXML
                    select new XElement("product",
                    new XAttribute("id", p.ProductID),
                    new XAttribute("price", p.Cost),
                    new XElement("name", p.ProductName)));
                WriteLine(xml.ToString());

                // save the document
                var doc = new XDocument(xml);
                doc.Save("document.xml");

                // read it back as a string
                WriteLine("\n\nHave saved the document as an XML file so reading it back as a string\n");
                WriteLine(File.ReadAllText("document.xml"));

                // read it back as XML
                WriteLine("\n\nNow reading it back as XML");
                XDocument doc2 = XDocument.Load("document.xml");

                //var xmlOutput = doc2.Descendants("products").Descendants("product").Select(node => new
                //{
                //    ID = node.Attribute("ID").Value,
                //    Price = node.Attribute("Price").Value
                //}).ToArray();

                //XDocument doc3 = new XDocument(xmlOutput);
                //doc3.Save("doc3.xml");
                //WriteLine(File.ReadAllText("doc3.xml"));


                // note at this point code is incomplete as don't really fully read back the document correctly 


            }
        }  // static void QueryingCategories()
        

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
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            // use SQLite
            // optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            // install nuget microsoft.entityframeworkcore.sqlserver -projectname entity_09_linq_to_xml
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
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


