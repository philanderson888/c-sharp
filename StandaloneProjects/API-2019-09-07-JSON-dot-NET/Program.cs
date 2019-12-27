using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_2019_09_07_JSON_dot_NET
{
    class Program
    {

        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            // The goal is to follow this tutorial
            // https://johnthiriet.com/efficient-api-calls/# 
            // which uses Http client
            BasicCallAsync();
            CallThenPrintCustomers();
            Console.ReadLine();
        }



        private static async void BasicCallAsync()
        {
            using (var client = new HttpClient())
            {
                var url = "https://raw.githubusercontent.com/philanderson888/data/master/customers.json";
                var content = await client.GetStringAsync(url);
                Console.WriteLine(content);
                customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                foreach(var c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-5}  {c.CustomerName,-10}  {c.Address}");
                }
            }


        }





        private static async void CallThenPrintCustomers()
        {
            customers = await TaskCallAsync();
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CustomerID,-5}  {c.CustomerName,-10}  {c.Address}");
            }
        }

        private static async Task<List<Customer>> TaskCallAsync()
        {
            using (var client = new HttpClient())
            {
                var url = "https://raw.githubusercontent.com/philanderson888/data/master/customers.json";
                var content = await client.GetStringAsync(url);
                Console.WriteLine(content);
                customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                return customers;
            }
        }
    }

    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
