using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;

namespace Encrypt_02
{
    class Program
    {

        static byte[] s_additionalEntropy = { 9, 8, 7, 6, 5 };

        static void Main(string[] args)
        {
            // This lab illustrates Protected Data

            // Raw data, in binary format
            byte[] rawBinary = { 30, 40, 50 };
            Console.WriteLine("Raw data is ");
            foreach (byte b in rawBinary) Console.Write(" {0}",b.ToString());
            // Encrypt
            byte[] encryptedData = Protect(rawBinary);
            Console.WriteLine();
            Console.WriteLine("Encrypted data is ");
            foreach (byte b in encryptedData) Console.Write(" {0}", b.ToString());
            Console.WriteLine();
        }

        public static byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
                
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Data);
                return null;
            }
        }
    }
}
