using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // shared : for every course it will have a number 
        // of enrollments
        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
