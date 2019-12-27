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
