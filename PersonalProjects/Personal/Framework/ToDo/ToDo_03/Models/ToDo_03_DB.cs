namespace ToDo_03
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class ToDo_03_Model : DbContext
    {
        public ToDo_03_Model() : base("name=ToDo_03_Model") { }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
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

        public Category()
        {
            Tasks = new HashSet<Task>();
        }

        public int CategoryID { get; set; }

        [Column("CategoryName")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }

    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }

        public class ToDo_Initializer : DropCreateDatabaseAlways<ToDo_03_Model>
        {
            protected override void Seed(ToDo_03_Model db)
            {
                var users = new List<User>
                {
                    new User { UserName="Dad"}
                };
                users.ForEach(user => db.Users.Add(user));
                var categories = new List<Category>
                {
                    new Category { CategoryName="Family"},
                    new Category { CategoryName="Work"}
                };
                categories.ForEach(category => db.Categories.Add(category));
                db.SaveChanges();
            
            }
        }
}