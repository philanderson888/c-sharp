using System.Xml.Linq;
using static System.Console;
using System.Xml;

namespace XML_01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\n\nMost basic element possible\n");
            var xml = new XElement("test", 1);
            WriteLine(xml);

            WriteLine("\n\nNow add a sub-element\n");
            xml = new XElement("test", 
                new XElement("subelement",1)
                );
            WriteLine(xml);

            WriteLine("\n\nNow add several\n");
            xml = new XElement("test",
                new XElement("subelement", 1),
                new XElement("subelement", 2),
                new XElement("subelement", 3)
                );
            WriteLine(xml);

            // create an XML properly-formed document, but use the contents of our XML string to fill this document
            var doc = new XDocument(XElement.Parse(xml.ToString()));
            doc.Save("Data.xml");

            WriteLine("\n\nNow add attributes\n");
            xml = new XElement("test",
                new XElement("subelement", 
                    new XAttribute("someattribute",11),1),
                new XElement("subelement",
                    new XAttribute("someattribute", 22), 2),
                new XElement("subelement",
                    new XAttribute("someattribute", 33), 3)
                );
            WriteLine(xml);


            WriteLine("\n\nNow add sub-elements and attributes\n");
            xml = new XElement("test",
                new XElement("subelement",
                    new XElement("subsubelement",44),
                    new XAttribute("someattribute", 11)),
                new XElement("subelement",
                    new XAttribute("someattribute", 22), 2),
                new XElement("subelement",
                    new XAttribute("someattribute", 33), 3)
                );
            WriteLine(xml);

            WriteLine("\n\nLoad back our XML from file Data.xml - as XML");
            var doc2 = new XmlDocument();
            doc2.Load("Data.xml");
            WriteLine(doc2.InnerXml);


        }
    }
}
