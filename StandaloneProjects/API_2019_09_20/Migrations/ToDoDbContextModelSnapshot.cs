﻿// <auto-generated />
using API_2019_09_20;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_2019_09_20.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    partial class ToDoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("API_2019_09_20.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Done");

                    b.Property<string>("ToDoItem");

                    b.HasKey("ToDoId");

                    b.ToTable("ToDoes");

                    b.HasData(
                        new { ToDoId = 1, Done = false, ToDoItem = "To Do" },
                        new { ToDoId = 2, Done = false, ToDoItem = "Also To Do" },
                        new { ToDoId = 3, Done = false, ToDoItem = "And To Do" },
                        new { ToDoId = 4, Done = true, ToDoItem = "Then To Do" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
