using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Migration_01_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            List<MigrationTest> people = new List<MigrationTest>();

            using (var db = new PhilDbEntities())
            {
                {
                    people = db.MigrationTests.ToList();
                }

                people.ForEach(p => Console.WriteLine(p.IsEnabled));
            }
        }
    }
}
