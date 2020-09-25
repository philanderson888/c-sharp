using System;
using System.ComponentModel;
using System.Linq;

namespace Codewars
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            IsSequenceValid("1 2 3 4");
            IsSequenceValid("1 2 3 4 a");
            IsSequenceValid("1 3 4 5");
            SumOfBinaryDigits(1234);
            FindNumberOfSubstringsInAString("a a a  b  c c  d d d d  e e e e e");
        }
        #endregion Main
        #region IsASequenceValid
        static int IsSequenceValid(string sequence)
        {
            /*
                https://www.codewars.com/kata/5512e5662b34d88e44000060
                Check if item part of broken sequence or not
            */
            Console.WriteLine($"is this sequence valid? {sequence}");
            if (sequence == null) return 0;
            if (sequence == "") return 0;
            // check for invalid characters
            foreach(char c in sequence)
            {
                if (!(Char.IsDigit(c)||Char.IsWhiteSpace(c)))
                {
                    Console.WriteLine($"Invalid character {c} present");
                }
            }
            string[] numbers = sequence.Split(" ");
            int previousNumber = 0;
            int missingNumber = 0;
            foreach(var number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    if (result - previousNumber != 1)
                    {
                        missingNumber = previousNumber + 1;
                        break;
                    }
                }
            }
            if (missingNumber > 0)
            {
                Console.WriteLine($"Number {missingNumber} is missing from sequence");
                return missingNumber;
            }
            return 0;
        }
        #endregion IsASequenceValid
        #region SumOfBinaryDigits
        static int SumOfBinaryDigits(int n)
        {
            Console.WriteLine($"Printing sum of binary digits given integer {n}");
            // null 
            if (n <= 0) return 0;
            if (n == 1) return 1;
            var binary = Convert.ToString(n, 2);
            Console.WriteLine($"{n} as binary is {binary}");
            int total = 0;
            foreach(var item in binary)
            {
                Console.Write($"{item}, ");
                var sb = new System.Text.StringBuilder();
                sb.Append(item);
                int.TryParse(sb.ToString(),out int result);
                total += result;
            }
            Console.WriteLine($"Total of digits is {total}");
            // here is an easier way
            int total2 = binary.Count(item => item == '1');
            return total2;
        }
        #endregion SumOfBinaryDigits

        #region FindNumberOfSubstringsInAString
        static string[] FindNumberOfSubstringsInAString(string s) {
            /*
            https://www.codewars.com/kata/51e056fe544cf36c410000fb/train/csharp
            find occurrences of substring in string
            */

            return new string[0];
        }
        #endregion FindNumberOfSubstringsInAString

    }
}
