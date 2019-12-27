using System;
using Newtonsoft.Json;

namespace Serialize_JSON_Dot_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            //serialize
            string output = JsonConvert.SerializeObject(product);
            Console.WriteLine(output);

            // de-serialize
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            Console.WriteLine(deserializedProduct.Name);
        }
    }
    class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
