using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FamilyApp_2019_10_12
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
            services.AddDbContext<FamilyDbContext>();


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

    public class DadDailyItem
    {
        public int DadDailyItemId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TodaysDate { get; set; } = DateTime.Today;
        
        public bool UpOnTime { get; set; }
        public bool GetEarlyTrain { get; set; }

        public bool CallPhilip550 { get; set; }
        public bool CallChrista550 {get;set;}
        [Display(Name ="Work At Finsbury Park")]
        public bool WorkAtFinsburyPark { get; set; }
        public bool HitTheGym { get; set; }
    }

    public class FamilyDbContext : DbContext
    {
        private static bool _dbCreated = false;
        public FamilyDbContext()
        {
            if (!_dbCreated)
            {
                _dbCreated = true;
               // Database.EnsureDeleted();
               // Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"DataSource=FamilyDatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DadDailyItem>().HasData(
                new
                {
                    DadDailyItemId = 1,
                    TodaysDate = DateTime.Parse("1/10/2019")
                ,
                    UpOnTime = false,
                    GetEarlyTrain = false,
                    CallPhilip550 = false,
                    CallChrista550 = false,
                    WorkAtFinsburyPark = false,
                    HitTheGym = false
                }
                );
        }
    
        public DbSet<DadDailyItem> DadDailyItems { get; set; }
    }
}
