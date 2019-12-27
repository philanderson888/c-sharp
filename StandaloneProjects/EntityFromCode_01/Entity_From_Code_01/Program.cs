using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Entity_From_Code_01
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new SchoolContext())
            {
                var students = db.Students.ToList();

                foreach(var s in students)
                {
                    Console.WriteLine($"{s.StudentID} has name {s.StudentName}");
                }

            }

            using (var db = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Bill" };

                db.Students.Add(stud);
                db.SaveChanges();
            }



            Console.WriteLine("Done");

            using (var db = new SchoolContext())
            {
                var students = db.Students.ToList();

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.StudentID} has name {s.StudentName}");
                }

            }
        }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("StudentDatabase01")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Grade Grade { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
