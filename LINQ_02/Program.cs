using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable priceList = new Hashtable();
            priceList.Add("Cappucino", 2.35M);
            priceList.Add("Latte", 1.65M);
            priceList.Add("Coffee", 1.35M);
            var lowCost =
                from string drink in priceList.Keys
                where (Decimal)priceList[drink] < 2.00M
                orderby priceList[drink] ascending
                select (Decimal)priceList[drink];
            foreach (decimal d in lowCost)
            {
                Console.WriteLine(d);
            }


        }
    }
}
