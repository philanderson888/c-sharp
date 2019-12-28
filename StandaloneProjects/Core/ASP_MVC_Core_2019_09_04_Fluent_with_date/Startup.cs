using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.SqlServer;
using MVC_2019_09_04_Fluent_with_date;

namespace MVC_2019_09_04_Fluent_with_date
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<LogItemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToDoDatabaseLocal")));
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }



    public class LogItemDbContext : DbContext
    {

        public LogItemDbContext(DbContextOptions<LogItemDbContext> options) : base(options) { }
        public DbSet<LogItem> LogItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Category>().HasMany(c => c.LogItems).WithOne(c => c.Category);
            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

            builder.Entity<User>().HasMany(u => u.Logs).WithOne(u => u.User);
            builder.Entity<User>().Property(u => u.UserName).IsRequired();

            builder.Entity<LogItem>().HasMany(l => l.Logs).WithOne(l => l.LogItem);
            builder.Entity<LogItem>().Property(l => l.LogItemDescription).IsRequired();

        }

        public DbSet<MVC_2019_09_04_Fluent_with_date.Log> Log { get; set; }
    }

    public class LogItem
    {

        public LogItem()
        {
            Logs = new HashSet<Log>();
        }
        public int LogItemId { get; set; }
     
        public string LogItemDescription { get; set; }

        public int LogItemPoints { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

    }

    public class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }

    public class Category
    {
        public Category()
        {
            LogItems = new HashSet<LogItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<LogItem> LogItems { get; set; }
    }


    public class Log
    {
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int LogItemId { get; set; }
        public LogItem LogItem { get; set; }
    }


}
