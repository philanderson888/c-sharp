using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Serialize_XML_02
{
    class Program
    {
        static void Main(string[] args)
        {



            Class01 instance01 = new Class01();          // create object
            instance01.n1 = 1111;                          // populate
            instance01.n2 = 4444;
            instance01.str = "Some String";
            instance01.setHidden(25);                      // hidden field : not serialized

            IFormatter formatter = new SoapFormatter();  // create serialization object

            Stream stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None);  // create object ready to receive streaming data

            formatter.Serialize(stream, instance01);  // serialize object and output to the stream

            stream.Close();


            // deserialize now
            FileStream streamRead = File.OpenRead("data.xml");
            Class01 instance02 = formatter.Deserialize(streamRead) as Class01;
            streamRead.Close();
            Console.WriteLine("Instance02 which has been DESERIALIAZED from the xml file");
            Console.WriteLine(instance02.n1);
            Console.WriteLine(instance02.n2);
            Console.WriteLine(instance02.str);
            Console.WriteLine("But hidden field was not serialized so is blank");
            Console.WriteLine(instance02.getHidden());



        }
    }



    // see https://docs.microsoft.com/en-us/dotnet/framework/serialization/basic-serialization
    [Serializable]
    public class Class01 : ISerializable
    {
        public Class01() { }
        protected Class01(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            n1 = (int)info.GetValue("AltN1", typeof(int)); ;                          // populate
            n2 = (int)info.GetValue("AltN2", typeof(int)); ;
            str = (string)info.GetValue("AltStr", typeof(string));

        }
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
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("AltN1", n1 * 2);
            info.AddValue("AltN2", n2 * 2);
            info.AddValue("AltStr", str + " * 2");
        }
    }


}
