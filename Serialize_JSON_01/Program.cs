using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;  // note : must add System.Web.Extentions reference first

namespace Serialize_JSON_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var obj = new Lad
            {
                firstName = "Markoff",
                lastName = "Chaney",
                dateOfBirth = new MyDate
                {
                    year = 1901,
                    month = 4,
                    day = 30
                }
            };
            var json = new JavaScriptSerializer().Serialize(obj);
            Console.WriteLine(json);
        }
    }


    public class MyDate
    {
        public int year;
        public int month;
        public int day;
    }

    public class Lad
    {
        public string firstName;
        public string lastName;
        public MyDate dateOfBirth;
    }



}
