namespace Entity_Code_From_Db
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolModel : DbContext
    {
        public SchoolModel()
            : base("name=SchoolModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Grade)
                .HasForeignKey(e => e.Grade_GradeId);
        }
    }
}
