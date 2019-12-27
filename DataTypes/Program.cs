using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            Debug.WriteLine("hi");
            int i = 1234567890;
            Int16 j = 12345;
            Int32 k = 1234567890;
            Int64 l = 1234567890123456789;

            float f = 1.23456789023456789F;  // F mandatory
            double d = 1.23456789023456789D;   // D optional
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);
            decimal dd = 1.2345678902345678901234M;  // M optional
            

            Console.WriteLine("Integers by default are 32 bits long.");
            Console.WriteLine("Example of int is {0}", i);
            Console.WriteLine("Example of {0} is {1}", j.GetType(),j);
            Console.WriteLine("Example of {0} is {1}", k.GetType(),k);
            Console.WriteLine("Example of {0} is {1}", l.GetType(), l);
            Console.WriteLine("Float f is 32 bits long.  Example is " + f + ".  Note that floats have 7 digit precision");
            Console.WriteLine("Double d is 64 bits long.  Example is " + d + ".  Note that doubles have 15 digit precision");
            Console.WriteLine("Decimal dd is 128 bit long.  Example is " + dd);


            long lg = 1234567890123456789;
            Console.WriteLine("Long lg is " + lg);

            bool b = true;
            Console.WriteLine("Boolean b is " + b);







            string x = "h";
            char c = Convert.ToChar(x);
            Console.WriteLine("Char c is " + c);



            Console.WriteLine();
            Console.WriteLine();
            Char char01 = 'a';
            Console.WriteLine(char01);

            Console.WriteLine("== Char From ASCII number ==");
            Char char02 = (char)121;
            Console.WriteLine(char02);

            Console.WriteLine();
            Console.WriteLine("== Char Array From Letters ==");
            Char[] charArray01 = { 'a', 'b', 'c' };
            foreach (char charItem in charArray01)
            {
                Console.WriteLine(charItem.ToString());
            }


            Char[] charArray02 = new char[10];  // blank char array


            Console.WriteLine();
            Console.WriteLine("== Char Array From Letters ==");
            Char[] charArray03 = new char[] { 'a', 'b', 'c' };
            foreach (char charItem in charArray02)
            {
                Console.WriteLine(charItem.ToString());
            }




            Console.WriteLine();
            Console.WriteLine("== Char Array From Numbers ==");
            char[] charArray04 = new char[] { (char)121, (char)122, (char)123 };
            foreach (char charItem in charArray04)
            {
                Console.WriteLine(charItem.ToString());
            }

            Console.WriteLine("== Convert.ToChar(x)==");
            var char05 = Convert.ToChar(121);
            Console.WriteLine(char05);












            byte byte01 = 248;
            Console.WriteLine("Byte bb is " + byte01);
            Byte byte02 = Convert.ToByte(255);



            Console.WriteLine();
            Console.WriteLine("==Bytes==");
            var byteArray = new byte[] { 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 255, 232 };
            foreach (byte bbb in byteArray)
            {
                Console.WriteLine(bbb.ToString());

            }


            foreach (byte bbb in byteArray)
            {
                Console.Write(Convert.ToChar(bbb));

            }






            int[] array01 = new int[10];        // 1d
            int[] array02 = { 1, 2, 3 };        // literals
            Console.WriteLine("array length is " + array02.Length);
            Console.WriteLine("array count is " + array02.Count());
            int[,] arraygrid = new int[5,5];    // 2d

            DateTime date01 = new DateTime();
            Console.WriteLine(date01);

            DateTime date02 = DateTime.Today;
            Console.WriteLine(date02);

            DateTime date03 = DateTime.Now;
            Console.WriteLine(date03);

            date03.AddDays(7);
            date03.AddDays(7.0);
            date03.Add(new TimeSpan(2000));
            Console.WriteLine(date03);
            date03.AddYears(24);
            Console.WriteLine(date03);

            var Interval01 = date03 - date02;
            Console.WriteLine(Interval01);

            Console.WriteLine();

            Console.WriteLine("Byte uses {0} bytes", sizeof(byte));
            Console.WriteLine("with min value {0}", byte.MinValue);
            Console.WriteLine("and max value {0}", byte.MaxValue);


            Console.WriteLine("Int uses {0} bytes", sizeof(int));
            Console.WriteLine("with min value {0}", int.MinValue);
            Console.WriteLine("and max value {0}", int.MaxValue);

            Console.WriteLine("Short uses {0} bytes", sizeof(short));
            Console.WriteLine("with min value {0}", short.MinValue);
            Console.WriteLine("and max value {0}", short.MaxValue);

            Console.WriteLine("Int uses {0} bytes", sizeof(long));
            Console.WriteLine("with min value {0}", long.MinValue);
            Console.WriteLine("and max value {0}", long.MaxValue);

            Console.WriteLine();
            Console.WriteLine("==Checked vs Not Checked==");
            // Not checked : i2 overflows
            int i1 = 2147483647;
            Console.WriteLine("Not checked : " + i1);
            int i2 = i1 * 2;
            Console.WriteLine("Not checked : {0}", i2);

            
            checked
            {
                int i3 = 2147483647;
                Console.WriteLine("Not checked : " + i3);
            // uncomment to create a runtime exception    int i4 = i1 * 2;
            //    Console.WriteLine("Not checked : {0}", i4);
            }

            //     Console.WriteLine(checked(3245234523453245324*100));

            Console.WriteLine(unchecked(3245234523453245324*100));




            var plainText = "hello world…";
            var rawBytes = Encoding.Default.GetBytes(plainText);



            // view details class t : Type { }


            // using letters to define
            var money01 = 1.27M;
            Console.WriteLine($"money01 = { money01}");
            var uu = 123L;
            Console.WriteLine($"uu = {uu}");
            var ss = (Int16)123;
            Console.WriteLine($"ss = {ss}");
            var ff = 1.23F;
            Console.WriteLine($"ff = {ff}");

            var y = 0f; // y is single
            Console.WriteLine($"y = {y}");
            var z = 0d; // z is double
            Console.WriteLine($"z = {z}");
            var r = 0m; // r is decimal
            Console.WriteLine($"r = {r}");
            var iii = 0U; // i is unsigned int
            Console.WriteLine($"iii = {iii}");
            var jjjj = 0L; // j is long (note capital L for clarity)
            Console.WriteLine($"jjj = {jjjj}");
            var kkkk = 0UL; // k is unsigned long (note capital L for clarity)
            Console.WriteLine($"kkkk = {kkkk}");



            // Default values
            Console.WriteLine("== default values == ");
            int myNum01 = new int();
            Console.WriteLine(myNum01);
            int myNum02 = default(int);
            Console.WriteLine(myNum02);

            string myString01 = default(string);
            Console.WriteLine(myString01);
            string myString02 = null;
            Console.WriteLine(myString02);




            //int.TryParse
            string myNumberAsString = "1234";
            int myNumber;
            int.TryParse(myNumberAsString, out myNumber);
            Console.WriteLine(myNumber);
            Console.WriteLine(myNumber.GetType());



            Console.ReadLine();



        }
    }




}
