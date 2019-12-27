# MVC Movie 

Path is StandaloneProjects\



https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-2.2&tabs=visual-studio

Using .NET Core 2.2 as version 3.0 is unpredictable

New MVC Core app, no authentication (that's cheating!)

Run and build the app to check it's working


```cs
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }

        public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
                    : base(options)
        {

        }
        public DbSet<Movie> Movies {get;set;}
    }
```

Connection String

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MoviesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```


DbContext


install-package Microsoft.EntityFrameworkCore

install-package Microsoft.EntityFrameworkCore.SqlServer


```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _2019_09_mvc_movies_02.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
```



Startup.cs

```cs
 services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```






