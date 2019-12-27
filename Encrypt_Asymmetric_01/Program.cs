using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Encrypt_Asymmetric_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var plainText = "hello world…";
            var rawBytes = Encoding.Default.GetBytes(plainText);
            var decryptedText = string.Empty;
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var useOaepPadding = true;
                var encryptedBytes = rsaProvider.Encrypt(rawBytes, useOaepPadding);

                var decryptedBytes = rsaProvider.Decrypt(encryptedBytes, useOaepPadding);
                decryptedText = Encoding.Default.GetString(decryptedBytes);

                foreach(byte b in encryptedBytes)
                {
                    Console.WriteLine(b.ToString());
                }
                Console.WriteLine();
                Console.WriteLine();
                foreach (byte b in encryptedBytes)
                {
                    Console.Write(Convert.ToChar(b));
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(decryptedText);
            }

        }
    }
}
