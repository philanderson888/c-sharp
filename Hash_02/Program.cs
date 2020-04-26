using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hash_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note : use https://cryptii.com/pipes/binary-to-base64 to verify these results independently

            var myString = "secret";
            
            Console.WriteLine("MD5");
            Console.WriteLine(myString.ToMD5());




            byte[] myStringAsBytes = Encoding.UTF8.GetBytes(myString);

            Console.WriteLine("SHA1");
            using (var hashingAlgorithm = SHA1.Create())
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                Console.WriteLine(hash);
            }

            Console.WriteLine("SHA256");
            Console.WriteLine(myString.ToSha256());
            Console.WriteLine("SHA256 as Base 64");
            Console.WriteLine(myString.ToSha256Base64());

            using (var hashingAlgorithm = SHA512.Create())
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                Console.WriteLine(hash);
            }

            using (var hashingAlgorithm = HMACSHA512.Create("HMACSHA512"))
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                Console.WriteLine(hash);
            }
        }
    }

    public static class Extension
    {
        public static string ToMD5(this string myString)
        {
            byte[] myStringAsBytes = Encoding.UTF8.GetBytes(myString);

            using (var hashingAlgorithm = MD5.Create())
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                var hash1 = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                Console.WriteLine(hash1);
                var hash2 = new StringBuilder();
                Array.ForEach(hashBytes, item => {
                    hash2.Append(item.ToString("x2"));
                });
                Console.WriteLine(hash2);
                Console.WriteLine("These match sha1-online hash for Phil which is");
                Console.WriteLine("9ec75097ce44559e94e404d6a2d395ab");
                return hash1;
            }
        }

        public static string ToSha256(this string myString)
        {
            byte[] myStringAsBytes = Encoding.UTF8.GetBytes(myString);

            using (var hashingAlgorithm = SHA256.Create())
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                var hash = new StringBuilder();
                Array.ForEach(hashBytes, item => {
                    hash.Append(item.ToString("x2"));
                });
                return hash.ToString();
            }


        }

        public static string ToSha256Base64(this string myString) {

            byte[] myStringAsBytes = Encoding.UTF8.GetBytes(myString);
            using (var hashingAlgorithm = SHA256.Create())
            {
                var hashBytes = hashingAlgorithm.ComputeHash(myStringAsBytes);
                return Convert.ToBase64String(hashBytes);

            }
        }

    }
}
