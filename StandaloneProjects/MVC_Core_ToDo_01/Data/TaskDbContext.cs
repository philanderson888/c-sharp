using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_ToDo_01.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext (DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Core_ToDo_01.Models.Task> Task { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired().HasMaxLength(15);
            builder.Entity<Category>().HasMany(c => c.Tasks).WithOne(t => t.Category);
            builder.Entity<Task>().HasOne(t => t.Category).WithMany(c => c.Tasks);
        }
    }
}
