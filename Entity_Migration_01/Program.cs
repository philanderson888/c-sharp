    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Collections.Generic;


    namespace Entity_Migration_01
    {
        class Program
        {
            static void Main(string[] args)
            {

                Console.WriteLine("\n\nAdd new student\n");
                using (var db = new SchoolContext())
                {
                    var student = new Student()
                    {
                        StudentName = "Bob"
                    };
                    var test = new Test() {
                        TestName = "test name",
                        AddThisOn = "add some data here"
                        
                    };

                    db.Students.Add(student);
                    db.Tests.Add(test);

                    db.SaveChanges();           
                }

            
                Console.WriteLine("\n\nCheck record has been added");
                using(var db = new SchoolContext())
                {
                    foreach(Student s in db.Students)
                    {
                        Console.WriteLine(s.StudentName);
                    }
                    foreach (Test t in db.Tests)
                    {
                        Console.WriteLine(t.TestName);
                    Console.WriteLine(t.AddThisOn);
                    }
                }
            }
        }

        public class SchoolContext : DbContext
        {
            public SchoolContext() : base("StudentDatabase04"){
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Entity_Migration_01.Migrations.Configuration>());
            }
            public DbSet<Student> Students { get; set; }
            public DbSet<Grade> Grades { get; set; }
            public DbSet<Test> Tests { get; set; }
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

        public class Test
        {
            public int TestId { get; set; }
            public string TestName { get; set; }
            public string AddThisOn { get; set; }
        }
    }
