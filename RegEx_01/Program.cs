using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegEx_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var longString = "some long long text here 349";
            var searchString = "long";

            var regEx01 = new Regex(searchString);
            var matchFound = regEx01.IsMatch(longString);
            Console.WriteLine("Match found? - {0}", matchFound);
            matchFound = Regex.IsMatch(longString, searchString, RegexOptions.None);
            Console.WriteLine("Match found? - {0}", matchFound);
            var matchesArray = regEx01.Matches(longString);
            foreach (var match in matchesArray)
            {
                Console.WriteLine(match);
            }
            var regexcustom = @"[0-9]{3}";
            var regEx02 = new Regex(regexcustom);
            matchFound = regEx02.IsMatch(longString);
            Console.WriteLine(matchFound);
        }
    }
}
