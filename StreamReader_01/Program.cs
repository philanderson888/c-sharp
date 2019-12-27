using System;
using System.Text;
using System.IO;

namespace StreamReader_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("== Using test for reader.ReadLine() string is not null ==");
            StreamReader reader = new StreamReader("abc.txt");
            string oneLine = null;
            while ((oneLine = reader.ReadLine()) != null)
            {
                Console.WriteLine(oneLine);
            }

            Console.WriteLine("==using test for Not End Of Stream==");
            reader = new StreamReader("abc.txt");
            oneLine = null;
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }

            Console.WriteLine("==using test for Peek is not -1");
            int oneLetterCode;    // did you know the output from reader.read() is 
                                  //actually an integer representing the ASCII/Unicode 
                                  //number of the letter which has been stored!!!
            var char01 = new char();
            var sb = new StringBuilder();
            reader = new StreamReader("abc.txt");
            while(reader.Peek() != -1)
            {
                oneLetterCode = reader.Read();
                Console.WriteLine(oneLetterCode);
                char01 = (char)oneLetterCode;
                Console.WriteLine(char01);
                Console.WriteLine("--");
                sb.Append(char01);
            }

        }
    }
}
