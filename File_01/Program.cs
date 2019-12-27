using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // read abc.txt INTO ONE STRING
            Console.WriteLine("=string=");
            string input1 = File.ReadAllText("abc.txt");
            Console.WriteLine(input1);

            // read each line from abc.txt into ARRAY
            Console.WriteLine("=array=");
            string[] input2 = File.ReadAllLines("abc.txt");
            foreach (string item in input2)
            {
                Console.WriteLine("Array Line {0}", item);
            }

            // write one string to NEW FILE  def.txt
            File.WriteAllText("def.txt", input1);

            // append one line to EXISTING FILE  def.txt
            File.AppendAllText("def.txt", "\nsome really really extra text here");
            File.AppendAllText("abc.txt", "\nsome really really extra text here");

            

            //for (int i = 0; i <= 10; i++)
            //{
            //    File.AppendAllText("def.txt", DateTime.Now.ToString());
            //    System.Threading.Thread.Sleep(1000);
            //}


            // CREATE DIRECTORY
            Directory.CreateDirectory("Parent");

            // CREATE SUBDIRECTORY
            Directory.CreateDirectory("Parent\\Child");
            Directory.CreateDirectory("Parent\\Child\\Subchild");
            Directory.CreateDirectory("Parent\\Child2");

            // LIST ALL DIRECTORIES
            string[] directoryList = Directory.GetDirectories("Parent");
            foreach (var item in directoryList) { }



        }
    }
}
