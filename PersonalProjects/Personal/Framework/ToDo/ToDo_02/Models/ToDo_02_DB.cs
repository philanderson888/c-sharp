namespace ToDo_02
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ToDo_02_DB : DbContext
    {
        // Your context has been configured to use a 'ToDo_02_DB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ToDo_02.ToDo_02_DB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToDo_02_DB' 
        // connection string in the application configuration file.
        public ToDo_02_DB()
            : base("name=ToDo_02_DB")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }






    public partial class Task
    {
        public int TaskID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool? Done { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDone { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }


    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Tasks = new HashSet<Task>();
        }

        public int CategoryID { get; set; }

        [Column("Category1")]
        [StringLength(50)]
        public string Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }




    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}