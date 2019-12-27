# API Project

## Author : Phil Anderson 
## Date : September 20, 2019

Summary of the work : 

I have created three projects.

1. Create API using Entity Core.  This all works and creates a JSON API.

2. Read the data using a console app.  This works fine.

3. Read the data and display on an MVC web page.  This also works fine.


## Note : If you want to get this project to work for yourself you will have to modify the code before you run it and amend the API endpoints, so in this order

a) Run the API and get the endpoint for https://localhost:44300/api/ToDoLists  where the port will be different for your machine.

b) Keep this API running 

c) Change the API endpoints in both the other projects so they know where to look for the API data ie

  i) https://github.com/philanderson888/c-sharp/blob/master/StandaloneProjects/API/API_2019_09_20_Console_Core_READ_API/Program.cs line 15
  
  ii) https://github.com/philanderson888/c-sharp/blob/master/StandaloneProjects/API/API_2019_09_20_Read_API_Data_To_Website/Controllers/ToDoItemsController.cs line 16

# Building An API With ASP Core

Following this tutorial 

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio

This tutorial creates the following API:

    API	Description	Request body	Response body
    GET /api/TodoItems	Get all to-do items	None	Array of to-do items
    GET /api/TodoItems/{id}	Get an item by ID	None	To-do item
    POST /api/TodoItems	Add a new item	To-do item	To-do item
    PUT /api/TodoItems/{id}	Update an existing item  	To-do item	None
    DELETE /api/TodoItems/{id}    	Delete an item    	None	None

The resultant code all works and is present at `StandaloneProjects/API_2019_09_19_API_Core_From_Scratch`

Create 2.1 .NET Core Web App with API selected

```bash
Install Microsoft.EntityFrameworkCore        version 2.1.1
Install Microsoft.EntityFrameworkCore.SQLite version 2.1.1
Install Microsoft.EntityFrameworkCore.Design version 2.1.1
```

```csharp
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<ToDo> ToDoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("DataSource=DefaultDatabase");
        }
    }
```

In Startup.cs add

```csharp
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
```

then add


```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ToDoDbContext>(options => options.UseSqlite("DataSource=ToDoDatabase"));
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

Also I had to add a blank constructor in the ToDoDbContext file to make it work

```csharp
public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
    public DbSet<ToDo> ToDoes { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder builder)
    //{
    //    builder.UseSqlite("DataSource=DefaultDatabase");
    //}
    public ToDoDbContext() { }
}

```


### Add data with seeding


```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
    builder.Entity<ToDo>(item => {
        item.Property(i => i.ToDoId).IsRequired();
    });
    builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 1, ToDoItem = "Test", ToDoDone = false });
    builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 2, ToDoItem = "DoThis", ToDoDone = false });
    builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 3, ToDoItem = "Do That", ToDoDone = true });
}

```


### We can test this using `SQLite`.

Download SQLite and run these commands 

```bash
.open ToDoDatabase.db
.tables
select * from ToDoes
```


### Final Code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2019_09_19_API_Core_From_Scratch.Models
{
    public class ToDo
    {
        public long ToDoId { get; set; }
        public string ToDoItem { get; set; }
        public bool ToDoDone { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API_2019_09_19_API_Core_From_Scratch.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<ToDo> ToDoes { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlite("DataSource=DefaultDatabase");
        //}
        public ToDoDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDo>(item => {
                item.Property(i => i.ToDoId).IsRequired();
            });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 1, ToDoItem = "Test", ToDoDone = false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 2, ToDoItem = "DoThis", ToDoDone = false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId = 3, ToDoItem = "Do That", ToDoDone = true });
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using API_2019_09_19_API_Core_From_Scratch.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API_2019_09_19_API_Core_From_Scratch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToDoDbContext>(options => options.UseSqlite("DataSource=ToDoDatabase.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

```





# Rebuild - Second Attempt - Build Again API from scratch

Goal is to rebuild this project again from scratch under the title `API_2019_09_20_API`

New ASP Core 2.1 API Project

```bash
dotnet add package Microsoft.EntityFrameworkCore -v 2.1.1
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 2.1.1
dotnet add package Microsoft.EntityFrameworkCore.Design -v 2.1.1
```

Just build this out

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace API_2019_09_20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToDoDbContext>(options => options.UseSqlite("DataSource=../../data/ToDoDatabase.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class ToDo { 
        public int ToDoId { get; set; }
        public string ToDoItem { get; set; }
        public bool Done { get; set; }
    }

    public class ToDoCategory { }

    public class ToDoDbContext : DbContext {
        public ToDoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ToDo> ToDoes { get; set; }
        public ToDoDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<ToDo>(todo => todo.Property(t => t.ToDoId).IsRequired());
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId=1,ToDoItem="To Do",Done=false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId=2,ToDoItem="Also To Do",Done=false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId=3,ToDoItem="And To Do",Done=false });
            builder.Entity<ToDo>().HasData(new ToDo { ToDoId=4,ToDoItem="Then To Do",Done=true });
        }

    }
}

```


# To Do API Version 3 With Categories

### The goal with this iteration is to have database relationships with a primary and foreign key ie ToDo items with also a ToDo Category related as well

Build as before

.NET ASP Core 2.1 Project

This version is complete and can be seen at `API_2019_09_20_ToDo_With_Categories`



# Read ToDo API With Console App

Now let's see if we can read this API.  

Let's try with a console app first.

Create a console app in .NET Core `API_2019_09_20_Console_Core_READ_API`

Add Entity with 

```bash
dotnet add package Microsoft.EntityFrameworkCore -v 2.1.1
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 2.1.1
dotnet add package Microsoft.EntityFrameworkCore.Design -v 2.1.1
dotnet add package Newtwonsoft.Json
```

Add in our classes ToDoList and Category 

```csharp
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}

public class ToDoList
{
    public int ToDoListId { get; set; }
    public string ToDoItem { get; set; }
    public bool Done { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateDone { get; set; }

    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }


}
```

Finally add in the logic to read the API

```csharp
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace API_2019_09_20_Console_Core_READ_API
{


    class Program
    {

        static List<ToDoList> todoitems = new List<ToDoList>();
        static string url = "https://localhost:44300/api/ToDoLists";


        static void Main(string[] args)
        {
            GetToDoListAsync();
            var counter = 0;
            while (true)
            {
                Console.WriteLine($"Search has taken {counter}/10 seconds");
                System.Threading.Thread.Sleep(100);
                counter++;
                if ((todoitems != null) && (todoitems.Count>0))
                {
                    todoitems.ForEach(todo => Console.WriteLine(todo.ToDoItem));
                    break;
                }
            }

        }

        static async void GetToDoListAsync()
        {
            using (var client = new HttpClient())
            {
                var fullToDoList = await client.GetStringAsync(url);
                todoitems = JsonConvert.DeserializeObject<List<ToDoList>>(fullToDoList);

            }
        }
    }
}
```




# Website : Converting API data to JSON then displaying on a website

Let's now see if we can get this data onto a website page

New MVC Core website using .NET 2.1

Add a controller

```csharp
public class ToDoItemsController : Controller
{
    static List<ToDoList> todoitems = new List<ToDoList>();
    static string url = "https://localhost:44300/api/ToDoLists";
    // GET: ToDoItems
    public ActionResult Index()
    {
        using (var client = new HttpClient())
        {
            var fullToDoList = client.GetStringAsync(url);
            todoitems = JsonConvert.DeserializeObject<List<ToDoList>>(fullToDoList.Result);

        }
        return View(todoitems);
    }
}
```

Add a view using the scaffolding and the data all displays.


## Summary

I have created three projects.

1. Create API using Entity Core.  This all works and creates a JSON API.

2. Read the data using a console app.  This works fine.

3. Read the data and display on an MVC web page.  This also works fine.













