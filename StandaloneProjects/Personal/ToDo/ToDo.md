# ToDo 

## Contents

## Introduction

This is a test project to build ASP To Do applications from scratch

## SQL Script to populate the ToDo Database

```sql
use ASP_04_MVC
drop database ToDo 
go
create database ToDo
go
use ToDo
go
CREATE TABLE Categories(
   CategoryID INT NOT NULL IDENTITY PRIMARY KEY,
   Category NVARCHAR(50) NULL
);
CREATE TABLE Users(
	UserID INT NOT NULL IDENTITY PRIMARY KEY,
	UserName NVARCHAR(50) NOT NULL
);
CREATE TABLE RegularTasks
(
	RegularTaskID INT NOT NULL IDENTITY PRIMARY KEY, 
    CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
    Description NVARCHAR(50) NULL, 
    Done BIT NULL, 
	UserID INT NULL FOREIGN KEY REFERENCES Users(UserID),
	DateDone Date NULL
);


INSERT INTO Categories (Category) values ('Family');
INSERT INTO Categories (Category) values ('Work');

INSERT INTO Users (UserName) values ('Dad');

insert into RegularTasks (CategoryID,Description,Done,UserID)
values(1,'Family',1,1);
```

## Models

The models which are built are

```cs

namespace ToDo_01
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;



    public partial class RegularTask
    {
        public int RegularTaskID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Done { get; set; }
        public Nullable<int> UserID { get; set; }
 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateDone { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }

    
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.RegularTasks = new HashSet<RegularTask>();
        }
    
        public int CategoryID { get; set; }
        public string Category1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegularTask> RegularTasks { get; set; }
    }

     public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.RegularTasks = new HashSet<RegularTask>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegularTask> RegularTasks { get; set; }
    }


}
```

## ToDo_01

ToDo_01 is built as ASP.NET MVC Framework project with Database-First Entity.

## ToDo_02

ToDo_02 is built as ASP.NET MVC Framework project with Code-First Entity

Initially we built these classes from Code-First but importing Entity from the existing database

This produced the following classes

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;


namespace ToDo_02.Models
{

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


    public partial class ToDoModel : DbContext
    {
        public ToDoModel()
            : base("")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Task> RegularTasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
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
```

We also installed `Entity`

```bash
install-package EntityFramework -projectname ToDo_02
```

We can now build the project then add a Controller based on Entity from these classes

We should now be able to view the site and the database when we run the site.

See ToDo_02 for a working example of this

### Last Version In .NET Framework : ASP MVC Entity ToDo Site

Build a new project.

Add In Entity and give the model a name eg ToDo_03_Model which will now scaffold

Paste in these classes into the Models folder

```cs
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
}
```

```cs
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
```

We can also update the Bootstrap navbar links

```cshtml
<li>@Html.ActionLink("Home", "Index", "Home")</li>
<li>@Html.ActionLink("Users", "Index", "Users")</li>
<li>@Html.ActionLink("Categories", "Index", "Categories")</li>
<li>@Html.ActionLink("Tasks", "Index", "Tasks")</li>
```





