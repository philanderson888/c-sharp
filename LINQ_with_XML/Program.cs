using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_with_XML
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument doc = XDocument.Load("settings.xml");

            var appSettings = doc.Descendants("appSettings").Descendants("add").Select(node => new
            {
                Key = node.Attribute("key").Value,
                Value = node.Attribute("value").Value
            }).ToArray();

            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key} has value {item.Value}");
            }



        }
    }
}
