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

namespace API_2019_09_20_ToDo_With_Categories
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
            services.AddDbContext<ToDoDbContext>(options => options.UseSqlite("DataSource=ToDoDatabase4.db"));
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


    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class ToDoList {
        public int ToDoListId { get; set; }
        public string ToDoItem { get; set; }
        public bool Done { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDone { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }

    public class ToDoDbContext : DbContext {

        public ToDoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ToDoList> ToDoLists { get; set; }
         public DbSet<Category> Categories { get; set; }

        public ToDoDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoList>(item => item.Property(todolist => todolist.ToDoListId).IsRequired());
            builder.Entity<Category>(item => item.Property(c => c.CategoryId).IsRequired());
            builder.Entity<Category>(item => item.Property(c => c.CategoryName).IsRequired());
            builder.Entity<Category>().HasData(new Category { CategoryId=1,CategoryName="work"});
            builder.Entity<Category>().HasData(new Category { CategoryId=2,CategoryName="leisure"});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=1,ToDoItem="To Do",Done=false});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=2,ToDoItem="To Do Also",Done=false});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=3,ToDoItem="Then To Do",Done=false});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=4,ToDoItem="To Do This Also",Done=true});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=5,ToDoItem="To Do This Also",Done=true, CategoryId=1});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=6,ToDoItem="To Do This Also",Done=true, CategoryId=2});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=7,ToDoItem="To Do This Sometimes",Done=true, CategoryId=2});
            builder.Entity<ToDoList>().HasData(new ToDoList { ToDoListId=8,ToDoItem="To Do This Whenever",Done=false, CategoryId=1});
        }



    } 

}
