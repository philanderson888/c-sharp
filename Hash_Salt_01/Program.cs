#region using Cryptography and LINQ
using System;
using System.Security.Cryptography;
using System.Linq;
#endregion
namespace Hash_Salt_01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Generate A New Hash And Just Read The Salt
            var salt = new Hash().Salt;
            #endregion
            #region Print Out The Salt Byte Array
            Console.WriteLine("Salt as hex");  
            Console.WriteLine(BitConverter.ToString(salt));
            Console.WriteLine("Salt as decimal bytes");
            foreach(var item in salt){
                Console.Write(item + "   ");
            }
            #endregion
        }
    }
    #region Class Hash - Generates A Salt
    class Hash
    {
        private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
        public static readonly int DefaultSaltSize = 8; // 64-bit salt
        public readonly byte[] Salt;
        public readonly byte[] Passhash;

        public Hash()
        {
            Salt = GenerateSalt(DefaultSaltSize);
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            // This generates salt.
            // Rephrasing Schneier:
            // "salt" is a random string of bytes that is
            // combined with password bytes before being
            // operated by the one-way function.
            byte[] salt = new byte[saltSize];
            rng.GetBytes(salt);
            return salt;
        }
    }
    #endregion
}
