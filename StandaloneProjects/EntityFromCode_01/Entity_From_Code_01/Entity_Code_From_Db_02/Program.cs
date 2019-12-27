using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Code_From_Db_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolModel())
            {
               var stud = new Student() { StudentName = "Bill" };
            //    var test = new TestTable() { TestName = "Fred" };
            //   db.Students.Add(stud);
                
          //      db.SaveChanges();
            }



            Console.WriteLine("Done");

            using (var db = new SchoolModel())
            {
           //    var students = db.Students.ToList();

            //    foreach (var s in students)
            //    {
            //        Console.WriteLine($"{s.StudentId} has name {s.StudentName}");
            //    }

            }

        }
    }
}
