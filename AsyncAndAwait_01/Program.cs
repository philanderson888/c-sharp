using System;
using System.Collections.Generic;
using System.IO;

namespace AsyncAndAwait_01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("abc.txt"))
            {
                for (int i = 1; i < 1000;i++)
                {
                    File.AppendAllText("abc.txt", "Line " + i);
                }

            }
            Console.WriteLine("Control in main thread BEFORE ASYNC CALLED");
            ReadFileAsync();
            ReadFileAsync2();
            Console.WriteLine("Control in main thread AFTER ASYNC CALLED");
            Console.ReadLine();
            File.Delete("abc.txt");
        }

        private async static void ReadFileAsync()
        {
            char[] buffer;

            Console.WriteLine("Control in Method ReadFileAsync() BEFORE ASYNC CALLED");

            using (var reader = new StreamReader("abc.txt"))
            {
                buffer = new char[(int)reader.BaseStream.Length];
                await reader.ReadAsync(buffer, 0, (int)reader.BaseStream.Length);
            }
            Console.WriteLine("Control in Method ReadFileAsync() AFTER ASYNC CALLED");
        }

        static List<string> list = new List<string>();

        private static async void ReadFileAsync2()
        {
            Console.WriteLine("Control in Method ReadFileAsync2() BEFORE ASYNC CALLED");
            using (var reader = new StreamReader("abc.txt"))
            {
                while (true)
                {
                    string line = await reader.ReadLineAsync();
                    if (line == null) { break; }
                    list.Add(line);
                }
            }
            Console.WriteLine("Control in Method ReadFileAsync2() AFTER ASYNC CALLED");
        } 
    }
}
