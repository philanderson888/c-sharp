using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Entity_08_Northwind_Category_Product_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            bool addProductSuccess = AddProduct(6, "Curried Beef Pie", 47.00M, 150, out int productID);
            WriteLine($"\n\nNew product added - successful? {addProductSuccess} - new ID {productID}\n\n");
            int newCost = 100;
            bool updateCostSuccess = UpdateCost(productID, newCost);
            WriteLine($"{productID} has been updated with new cost of {newCost}");
            int numProductsDeleted = deleteProduct(productID - 1);
            WriteLine($"{numProductsDeleted} product has been deleted which had ID {productID-1}");
            QueryingCategories();
        }
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have");
                var categories = db.Categories.Include(c => c.Products);
                foreach (var c in categories)
                {
                    WriteLine($"\n\n{c.CategoryName} has ID {c.CategoryID} and description {c.Description}.  It has {c.Products.Count} products\n");
                    WriteLine($"{"Product",-40}{"ID",-20}{"Cost",-20}{"Stock",-20}");
                    WriteLine($"{"-------",-40}{"--",-20}{"----",-20}{"-----",-20}");
                    foreach (Product p in c.Products)
                    {
                        WriteLine($"{p.ProductName,-40}{p.ProductID,-20}{p.Cost,-20}{p.Stock,-20}");
                    }
                }

                WriteLine("\n\n\nAlso list products\n");
                decimal price = 40.0M;

                var products = db.Products;

                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20}");
                }

                var products2 = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);

                WriteLine("\n\n\nProducts in order greater than a set price\n");
                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products2)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20:£#,##0.00}");
                }

                WriteLine("\n\nNow using 'like' keyword to search using part of product name");
                var likeString = "che";
                var products3 = db.Products
                    .Where(product => EF.Functions.Like(product.ProductName, $"%{likeString}%"));
                foreach(Product p in products3)
                {
                    WriteLine($"{p.ProductName} has {p.Stock} items in stock at price {p.Cost}");
                }


                var products4 = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.Cost,
                        product.Stock
                    });

                WriteLine("\n\n\nProducts in order greater than a set price");
                WriteLine("More efficient query as only returning desired column\n");
                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (var product in products4)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20:£#,##0.00}");
                }

                WriteLine("\n\nTranslating To XML\n");
                var ProductsToXML = db.Products.Take(3);
                var xml = new XElement("products",
                    from p in ProductsToXML
                    select new XElement("product",
                    new XAttribute("id",p.ProductID),
                    new XAttribute("price",p.Cost),
                    new XElement("name",p.ProductName)));
                WriteLine(xml.ToString());

                // save the document
                var doc = new XDocument(xml);
                doc.Save("xmlOutput.xml");
                WriteLine("Have saved the document as an XML file so reading it back");
                WriteLine();



            }
        }  // static void QueryingCategories()

        static bool AddProduct(int CategoryID, string ProductName, decimal? Price, short? Stock, out int ProductID)
        {
            using (var db = new Northwind())
            {

                var product = new Product
                {
                    CategoryID = CategoryID,
                    ProductName = ProductName,
                    Cost = Price,
                    Stock = Stock
                };

                db.Products.Add(product);
                int affected = db.SaveChanges();
                ProductID = product.ProductID;
                return (affected == 1);
            }
        }  // static bool AddProduct()


        static bool UpdateCost(int productID,decimal newCost)
        {
            using (var db = new Northwind())
            {
                Product product = db.Products.First(p => p.ProductID == productID);
                product.Cost = newCost;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }  // static bool UpdateCost()

        static int deleteProduct(int productID) {
            using (var db = new Northwind())
            {
                // note that this produces a collection of products for multiple deletion
                var productsToDelete =
                    db.Products.Where(p => p.ProductID == productID);
                db.Products.RemoveRange(productsToDelete);
                int affected = db.SaveChanges();
                return affected;
            }
        }  // static int deleteProduct()

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
            // this path is valid on a MAC
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../../../../data/Northwind.db");
        
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

