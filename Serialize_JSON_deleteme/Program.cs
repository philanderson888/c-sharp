using System;
using System.Text;
using System.Runtime.Serialization;
// have to add reference to System.Runtime.Serialization first
using System.Runtime.Serialization.Json;  
using System.IO;

namespace Serialize_DataContractJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogSite blogEntry = new BlogSite()
            {
                Name = "C-sharpcorner",
                Description = "Share Knowledge"
            };

            Console.WriteLine("==Serializing JSON using DataContractSerializer==\n");
            
            // Create serialization object
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(BlogSite));
            
            // Stream serialized object to Memory
            // used to receive data back
            // string json = 
            // "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}";
            string json;
            using (MemoryStream msObj = new MemoryStream()) {
                // write object 
                js.WriteObject(msObj, blogEntry);

                // Read object back as a string (not deserializing here)
                // Set initial position of pointer to start of memory stream
                msObj.Position = 0;
                // read the memory stream
                using (var reader = new StreamReader(msObj))
                {
                    // "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}"  
                    // reading the JSON back as a string here
                    json = reader.ReadToEnd();
                    Console.WriteLine(json);
                }
            }

            // Now use deserialization

            Console.WriteLine("\n\n==DeSerializing JSON using DataContractSerializer==\n");
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(BlogSite));
                var blogEntry02 = (BlogSite)deserializer.ReadObject(ms);
                Console.WriteLine("Name: " + blogEntry02.Name); // Name: C-sharpcorner
                Console.WriteLine("Description: " + blogEntry02.Description); // Description: Share Knowledge  
            }
        }
    }

    [DataContract]
    class BlogSite
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
