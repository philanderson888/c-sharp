namespace Entity_Code_From_Db_02
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolModel, Migrations.Configuration>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseStudents").MapLeftKey("Course_CourseId"));

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Grade)
                .HasForeignKey(e => e.Grade_GradeId);
        }
    }
}
