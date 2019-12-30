using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace API_2019_09_20_Console_Core_READ_API
{
    class Program
    {
        static List<ToDoList> todoitems = new List<ToDoList>();
        static string url = "https://localhost:44300/api/ToDoLists";
        static void Main(string[] args)
        {
            CheckNetworkConnection("8.8.8.8");

            GetToDoListAsync();
            var counter = 0;
            while (true)
            {
                Console.WriteLine($"Search has taken {counter}/10 seconds");
                System.Threading.Thread.Sleep(100);
                counter++;
                if ((todoitems != null) && (todoitems.Count>0))
                {
                    todoitems.ForEach(todo => Console.WriteLine(todo.ToDoItem));
                    break;
                }
            }
            Console.ReadLine();
        }

        static void CheckNetworkConnection(string parameter)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"\n\nLoop {i}\n");
               
                PingReply reply = pingSender.Send(parameter, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine($"Message status is {reply.Status}");
                    Console.WriteLine($"IPStatus.Success is {IPStatus.Success}");
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    if (reply.Options != null)
                    {
                        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                        Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    }
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
                else
                {
                    Console.WriteLine($"Fail");
                }
            }
        }

        static async void GetToDoListAsync()
        {
            Console.WriteLine("\n\nGetting A JSON String And Deserialsing to a list");
            using (var client = new HttpClient())
            {
                var fullToDoList = await client.GetStringAsync(url);
                todoitems = JsonConvert.DeserializeObject<List<ToDoList>>(fullToDoList);
            }
        }
    }


    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string ToDoItem { get; set; }
        public bool Done { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDone { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
