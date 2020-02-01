using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVC_FamilyApp_2019_11_02_Core_SQL
{

    public class FamilyDbContext : IdentityDbContext
    {
        public FamilyDbContext(DbContextOptions<FamilyDbContext> options)
            : base(options)
        {
        }

        public DbSet<DailyLog> DailyLogs { get; set; }
    }

}
