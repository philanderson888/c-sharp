using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_10_Users_Categories
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
            services.AddDbContext<UserDatabaseContext>(options => options.UseSqlServer("DefaultConnection"));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }


    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = UserDatabase01");
            //builder.UseSqlite(@"Data Source = UsersAndCategories.db");
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }







}
