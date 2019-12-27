using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumper_01
{
    class Program
    {
        static void Main(string[] args)
        {



            Item item = new Item
            {
                Name = "Chocolate",
                Number = 12345,
                CreatedDate = DateTime.Now,
                Price = 36.7M,
                Category = new Category(1, "Sweets")
            };

            using (var writer = new System.IO.StringWriter())
            {
                ObjectDumper.Dumper.Dump(item, "Object Dumper", writer);
                Console.Write(writer.ToString());
            }




        }
    }

    class Item
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }

    class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Category(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
