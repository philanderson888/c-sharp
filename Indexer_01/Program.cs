using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var IndexerObject = new Indexer01();
            IndexerObject[0] = 1;
            Console.WriteLine(IndexerObject[0]);
            IndexerObject[1] = 2;
            Console.WriteLine(IndexerObject[1]);
            IndexerObject[2] = 3;
            Console.WriteLine(IndexerObject[2]);
            IndexerObject[3] = 4;
            Console.WriteLine(IndexerObject[3]);


        }

    }

    class Indexer01
    {
        private int[] internalArray = new int[100];

        public int this[int i]
        {
            get { return internalArray[i]; }
            set { internalArray[i] = value; }
        }
    }

}
