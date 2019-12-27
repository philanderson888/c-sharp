using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_FamilyApp_2019_11_02_Core_SQL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVC_FamilyApp_2019_11_02_Core_SQL
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

#if DEBUG
            var connectionString = Environment.GetEnvironmentVariable("AzureFamilyDatabase04");
#else
            var connectionString = Environment.GetEnvironmentVariable("APPSETTING_FamilyDatabase04");
#endif
           services.AddDbContext<FamilyDbContext>(options => options.UseSqlServer(connectionString));


            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<FamilyDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }




    public class DailyLog
    {
        public int DailyLogId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LogDate { get; set; }

        public String Comments { get; set; }
        public bool UpOnTime { get; set; }
        public bool StayedUp { get; set; }
        public bool MadeGym { get; set; }
        public bool PrWthFam { get; set; }
        public bool PrWthZ { get; set; }
        public bool CrsPryPhoto { get; set; }
        public bool PhilPryPhoto { get; set; }
        public bool CrsDeskPhoto { get; set; }
        public int NbrSns { get; set; }
    }
    public class FamilyDbContext : IdentityDbContext
    {
        public FamilyDbContext(DbContextOptions<FamilyDbContext> options)
            : base(options)
        {
        }

        public DbSet<DailyLog> DailyLogs { get; set; }
    }


}
