using System;
using System.Net.Http;

namespace API_2019_09_08_API_from_scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWebDataAsync();
        }

        static async void GetWebDataAsync()
        {
            Console.WriteLine("\nGetting Web Data\n\n");
            using (var client = new HttpClient())
            {

                var url = "https://raw.githubusercontent.com/philanderson888/data/master/customers.json";
                var output = await client.GetAsync(url);
                var output2 = await client.GetStringAsync(url);
                Console.WriteLine(output);
                Console.WriteLine(output2);
                Console.ReadLine();


            }
        }
    }
}
