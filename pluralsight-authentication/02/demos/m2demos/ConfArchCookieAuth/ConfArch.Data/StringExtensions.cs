using System;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace ConfArch.Data
{
    public static class StringExtensions
    {
        public static string Sha256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                Console.WriteLine($"input bytes are");
                Array.ForEach(bytes, b => {
                    Console.WriteLine(b);
                });
                var hash = sha.ComputeHash(bytes);
                Console.WriteLine("\nhashed bytes are");
                Array.ForEach(hash, b => {
                    Console.WriteLine($"{b,-10}{Convert.ToChar(b)}");
                });
                Console.WriteLine($"base 64 string is {Convert.ToBase64String(hash)}");
                return Convert.ToBase64String(hash);
            }
        }
    }
}
