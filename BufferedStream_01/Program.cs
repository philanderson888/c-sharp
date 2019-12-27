using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BufferedStream_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // see http://o7planning.org/en/10535/csharp-streams-tutorial-binary-streams-in-csharp
            String fileName = "MyFile.txt";

            FileInfo file = new FileInfo(fileName);

            // Make sure the directory exists.
            file.Directory.Create();

            // Create a new file, if it exists it will be overwritten.
            // Returns FileStream object.
            using (FileStream fileStream = file.Create())
            {
                // Create BufferedStream wrap the FileStream.
                // (Specify the buffer is 10000 bytes).
                using (BufferedStream bs = new BufferedStream(fileStream, 100))
                {
                    int index = 0;
                    for (index = 1; index < 2000; index++)
                    {
                        String s = "This is line " + index + "\n";

                        byte[] bytes = Encoding.UTF8.GetBytes(s);

                        // Write to buffer, when the buffer is full it will
                        // automatically push down the file.
                        bs.Write(bytes, 0, bytes.Length);
                    }

                    // Flushing the remaining data in the buffer to the file.
                    bs.Flush();
                }

            }

            Console.WriteLine("Finished!");
            Console.Read();

        }
    }
}
