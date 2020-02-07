#region Using Libraries
using System;
using System.Security.Cryptography;
#endregion
namespace Hash_Salt_02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Declare Variables salt
            byte[] salt;  // this will hold the salt
            #endregion
            #region Generate And Print New Salt
            new RNGCryptoServiceProvider().GetBytes(salt=new byte[16]);
            Console.WriteLine("New Salt Is Generated Which Is");
            Console.WriteLine(BitConverter.ToString(salt));
            #endregion
            #region Get Initial Password
            Console.WriteLine("Please Enter Password");
            string initialPassword = Console.ReadLine();
            #endregion
            #region Join Salt To Password And Generate Hash With PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(initialPassword, salt, 10000);
            // getbytes places a string into a byte array
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashbytes = new byte[36];
            // Array.Copy(array1,startindex,array2,startdestinationindex,lengthtocopy)
            Array.Copy(salt, 0, hashbytes, 0, 16);  // copy 16 bytes from salt to hashbytes
            Array.Copy(hash, 0, hashbytes, 16, 20); // copy 20 bytes from hash to hashbytes
            string savedPasswordHash = Convert.ToBase64String(hashbytes);
            Console.WriteLine("Hash Bytes Array Holds");       
            Console.Write(BitConverter.ToString(hashbytes));
            Console.WriteLine();
            Console.WriteLine($"saved password hash is {savedPasswordHash} after converting to Base64 as a string");
            #endregion
        }
    }
}
