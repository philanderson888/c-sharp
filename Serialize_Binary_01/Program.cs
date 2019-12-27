using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialize_Binary_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Class01 instance01 = new Class01();          // create object
            instance01.n1 = 1111;                          // populate
            instance01.n2 = 4444;
            instance01.str = "Some Stringggg";
            instance01.setHidden(25);                      // hidden field : not serialized

            IFormatter formatter = new BinaryFormatter();  // create serialization object

            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);  // create object ready to receive streaming data

            formatter.Serialize(stream, instance01);  // serialize object and output to the stream

            stream.Close();


            // deserialize now
            Console.WriteLine("==");
            Console.WriteLine("Beginning deserialization process");
            FileStream streamRead = File.OpenRead("MyFile.bin");
            Class01 instance02 = formatter.Deserialize(streamRead) as Class01;
            streamRead.Close();
            Console.WriteLine("Instance02 which has been DESERIALIAZED from the binary file");
            Console.WriteLine(instance02.n1);
            Console.WriteLine(instance02.n2);
            Console.WriteLine(instance02.str);
            Console.WriteLine("But hidden field was not serialized so is blank");
            Console.WriteLine(instance02.getHidden());



            IFormatter formatter2 = new BinaryFormatter();
            using (var stream01 = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // create an instance which we are about to serialize (think 'flat pack a wardrobe')
                var instance03 = new MyClass();
                // serialize the instance into binary.  Then stream it to the binary file as a stream.
                formatter2.Serialize(stream01, instance03);
            }

            using (var stream02 = File.OpenRead("MyFile.bin"))
            {
                // read back our data as a stream from the binary file, and convert it back into an instance of the MyClass and name it instance01
                var instance04 = formatter2.Deserialize(stream02) as MyClass;
            }
        }
    }


    // see https://docs.microsoft.com/en-us/dotnet/framework/serialization/basic-serialization

    [Serializable]
    public class Class01
    {
        [NonSerialized]
        private int _hidden_01;   // won't be included with serialization
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
        public void setHidden(int hidden)
        {
            this._hidden_01 = hidden;
        }
        public int getHidden()
        {
            return this._hidden_01;
        }
    }

    [Serializable]
    class MyClass
    {
        [NonSerialized]
        private int MyField;  // this field is not included
        public string Property01 { get; set; }
        public void DoThis()
        {
            // do something
        }
    }




}
