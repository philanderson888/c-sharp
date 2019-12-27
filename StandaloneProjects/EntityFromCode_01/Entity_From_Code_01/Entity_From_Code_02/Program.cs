using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Entity_From_Code_02
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new SchoolContext())
            {
                var students = db.Students.ToList();

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.StudentId} has name {s.StudentName}");
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
                    Console.WriteLine($"{s.StudentId} has name {s.StudentName}");
                }

            }

        }
    }


    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("StudentDatabase02")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Grade Grade { get; set; }

        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public virtual ICollection<Course> Courses { get; set; }

    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }


}






