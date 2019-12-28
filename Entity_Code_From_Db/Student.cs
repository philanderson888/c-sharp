namespace Entity_Code_From_Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public byte[] Photo { get; set; }

        public decimal Height { get; set; }

        public float Weight { get; set; }

        public int? Grade_GradeId { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
