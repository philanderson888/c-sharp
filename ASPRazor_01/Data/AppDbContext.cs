using Microsoft.EntityFrameworkCore;

namespace ASPRazor_01.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options) { }

        


        public DbSet<Customer> Customers { get; set; }
    }
}
