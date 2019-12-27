using System;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace Http_Get_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Async version of http get
            GetPage();  // have to call the method which is decorated with the async keyword
            Console.WriteLine("Control has returned to the main thread even though page has not yet arrived");
            System.Threading.Thread.Sleep(10);
            Console.WriteLine("Still no page - waiting . . . ");
            Console.ReadKey();
            Console.WriteLine(File.ReadAllText("page01.html"));
            Console.WriteLine("\n\nHit any key to load this page in a browser\n");
            Console.ReadKey();
            Process.Start("page01.html");
        }
        async static void GetPage()
        {
            var pageRequest01 = WebRequest.Create("http://www.albahari.com/nutshell/code.html");
            pageRequest01.Proxy = null;
            using (var response01 = await pageRequest01.GetResponseAsync())
            {
                using (var stream01 = response01.GetResponseStream())
                {
                    using (var fileStream01 = File.Create("page01.html"))
                    {
                        await stream01.CopyToAsync(fileStream01);
                        Console.WriteLine("file has arrived");
                        Console.WriteLine();
                        Console.WriteLine("===================");
                        Console.WriteLine("Request information");
                        Console.WriteLine(pageRequest01.AuthenticationLevel);
                        Console.WriteLine(pageRequest01.ContentLength);
                        Console.WriteLine(pageRequest01.ContentType);
                        Console.WriteLine(pageRequest01.Credentials);
                        foreach (var item in pageRequest01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine(pageRequest01.Headers);

                        Console.WriteLine();
                        Console.WriteLine("Getting Request Header Keys And Values");
                        foreach (var item in pageRequest01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        string[] requestHeaderInfo = pageRequest01.Headers.AllKeys;
                        foreach (string key in requestHeaderInfo)
                        {
                            Console.WriteLine();
                            Console.WriteLine(key);
                            foreach (string value in pageRequest01.Headers.GetValues(key))
                            {
                                Console.WriteLine(value);
                            }
                        }
                        Console.WriteLine(pageRequest01.ImpersonationLevel);
                        Console.WriteLine(pageRequest01.Method);
                        Console.WriteLine(pageRequest01.RequestUri);
                        Console.WriteLine(pageRequest01.Timeout);
                        Console.WriteLine(pageRequest01.UseDefaultCredentials);
                        Console.WriteLine(pageRequest01.ToString());
                        Console.WriteLine();
                        Console.WriteLine("===================");
                        Console.WriteLine("Response information");
                        Console.WriteLine(response01.ContentLength);
                        Console.WriteLine(response01.ContentType);
                        Console.WriteLine(response01.Headers.Count);
                        Console.WriteLine();
                        Console.WriteLine("Getting Header Keys And Values");
                        foreach (var item in response01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        string[] headerInfo = response01.Headers.AllKeys;
                        foreach (string key in headerInfo)
                        {
                            Console.WriteLine();
                            Console.WriteLine(key);
                            foreach (string value in response01.Headers.GetValues(key))
                            {
                                Console.WriteLine(value);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine(response01.IsFromCache);
                        Console.WriteLine(response01.IsMutuallyAuthenticated);
                        Console.WriteLine(response01.ResponseUri);
                        Console.WriteLine(response01.SupportsHeaders);
                        Console.WriteLine(response01.ToString());
                        Console.WriteLine("\n\nPress and key to see this page");
                    }
                }
            }
        }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Product
    {

        private decimal priceField;

        private ProductOtherDetails otherDetailsField;

        private byte idField;

        private string nameField;

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public ProductOtherDetails OtherDetails
        {
            get
            {
                return this.otherDetailsField;
            }
            set
            {
                this.otherDetailsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductOtherDetails
    {

        private string brandNameField;

        private string manufacturerField;

        /// <remarks/>
        public string BrandName
        {
            get
            {
                return this.brandNameField;
            }
            set
            {
                this.brandNameField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }
    }


    public class Rootobject
    {
        public Post[] posts { get; set; }
        public Profile profile { get; set; }
    }

    public class Profile
    {
        public string name { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
    }

}
