using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Hash_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var x = new EncryptMe();
            var dataToHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var secretKey = new byte[] { 0x20, 0x20, 0x20 };
            var output = x.ComputeHash(dataToHash,secretKey);
            var outputArray = output.ToArray<byte>();
            foreach (byte b in outputArray)
            {
                Console.WriteLine(b.ToString());
                
            }
            foreach (byte b in outputArray)
            {
                Console.Write(Convert.ToChar(b));

            }
            Console.WriteLine();
        }
    }

    class EncryptMe {

        public byte[] ComputeHash(byte[] dataToHash, byte[] secretKey)
        {
            using (var hashAlgorithm = new HMACSHA1(secretKey))
            {
                using (var bufferStream = new MemoryStream(dataToHash))
                {
                    return hashAlgorithm.ComputeHash(bufferStream);
                }
            }
        }

    }







}
