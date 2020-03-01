using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace EFCore_12_Samurai_01.Models
{
    public partial class UserDatabaseContext : DbContext
    {
        #region constructors
        public UserDatabaseContext()
        {

        }

        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options)
            : base(options)
        {
        }
        #endregion
        #region DbSet
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Testing> Testings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<FirstModel> FirstModels { get; set; }
        public virtual DbSet<SecondModel> SecondModels { get; set; }
        public virtual DbSet<FirstModelSecondModelJoiningTable> JoiningTable { get; set; }
        #endregion
        #region Logging
        public static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(builder=>builder.AddConsole());

        public static readonly ILoggerFactory ConsoleLoggerFactoryFiltered =
            LoggerFactory.Create(builder => {
                builder
                .AddFilter((category, level) =>
                {
                    return category == DbLoggerCategory.Database.Command.Name &&
                           level == LogLevel.Information;

                })
                .AddConsole();
            
            });
        #endregion
        #region OnConfiguring - Logging Options and SQL Server Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(ConsoleLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=UserMigrationDatabase;Integrated Security=True");
            }
        }
        #endregion
        #region OnModelCreating - Migrations Methods On Model Setup (Run Once Only)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.CompanyId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<FirstModelSecondModelJoiningTable>()
                .HasKey(item => new { item.FirstModelId, item.SecondModelId });

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<MainItem>().ToTable("MainItems");
            modelBuilder.Entity<SubItem>().ToTable("SubItems");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Admin" },
                new Category { CategoryId=2,CategoryName = "User" },
                new Category { CategoryId=3,CategoryName = "Personal" }
           );

            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId=1, CompanyName="Sparta"},
                new Company { CompanyId=2, CompanyName="BBC"},
                new Company { CompanyId=3, CompanyName="ITV"}
                
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Bob", CategoryId=1, CompanyId=1 },
                new User { UserId = 2, UserName = "Tim", CategoryId=2, CompanyId=2 },
                new User { UserId = 3, UserName = "Joe", CategoryId=3, CompanyId=3 }
                );

            modelBuilder.Entity<FirstModel>().HasData(
                new FirstModel { FirstModelId = 1, FirstModelName = "test one" },
                new FirstModel { FirstModelId = 2, FirstModelName = "test two" },
                new FirstModel { FirstModelId = 3, FirstModelName = "test three" }
                );

            modelBuilder.Entity<SecondModel>().HasData(
                new SecondModel { SecondModelId = 1, SecondModelName = "test one" },
                new SecondModel { SecondModelId = 2, SecondModelName = "test two" },
                new SecondModel { SecondModelId = 3, SecondModelName = "test three" }
            );

            modelBuilder.Entity<FirstModelSecondModelJoiningTable>().HasData(
                new FirstModelSecondModelJoiningTable { FirstModelId = 1, SecondModelId = 1 },
                new FirstModelSecondModelJoiningTable { FirstModelId = 2, SecondModelId = 2 },
                new FirstModelSecondModelJoiningTable { FirstModelId = 3, SecondModelId = 3 }
                );

            var subItem = new SubItem() { SubItemId = 1, SubItemName = "some sub item name"};
            modelBuilder.Entity<SubItem>().HasData(
                subItem
                );
        }
        #endregion OnModelCreating
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}