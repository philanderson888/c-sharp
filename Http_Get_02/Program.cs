using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http_Get_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the Synchronous version of a page read - thread hangs

            var pageRequest01 = WebRequest.Create("http://www.albahari.com/nutshell/code.html");
            pageRequest01.Proxy = null;
            using (var response01 = pageRequest01.GetResponse()) {
                using(var stream01 = response01.GetResponseStream())
                {
                    using (var fileStream01 = File.Create("page01.html"))
                    {
                        stream01.CopyTo(fileStream01);
                    }
                }
            }



        }
    }
}
