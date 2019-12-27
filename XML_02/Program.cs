using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;


namespace XML_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {


                var xml = new XElement
                ("Products",
                    from p in db.Products.ToList<Product>()
                    select new XElement
                    ("Product",
                        new XElement("ProductID", p.ProductID),
                        new XElement("ProductName", p.ProductName),
                        new XElement("UnitPrice", p.UnitPrice)
                    )
                );
                Console.WriteLine(xml);

                XDocument doc = new XDocument(XElement.Parse(xml.ToString()));

                doc.Save("Data.xml");

                XDocument doc2 = new XDocument(
                new XElement("Student",
                new XElement("Name", "John"),
                new XElement("Age", "17"),
                XElement.Parse(xml.ToString())));

                doc2.Save("Data2.xml");



                string ProductData =
                    @"<ProductCollection>
                        <Product>
                            <ProductID>1</ProductID>
                        </Product>
                    </ProductCollection>";

                Console.WriteLine("\n\nNow let's deserialize back into products\n");
                // create a collection to hold our data
                var products = new Products();
                // stream our data back in from file
                using (StreamReader reader = new StreamReader("Data.xml"))
                {
                    // create the serializer
                    XmlSerializer serializer = new XmlSerializer(typeof(Products));
                    // serialize the product list to a collection 
                    products = (Products)serializer.Deserialize(reader);
                }

                foreach (Product p in products.ProductList)
                {
                    Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-50}{p.UnitPrice}");
                }

            }
        }
    }


    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
    }
}
