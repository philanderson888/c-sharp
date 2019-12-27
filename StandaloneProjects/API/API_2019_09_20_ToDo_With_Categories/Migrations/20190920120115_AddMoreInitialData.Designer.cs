﻿// <auto-generated />
using System;
using API_2019_09_20_ToDo_With_Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_2019_09_20_ToDo_With_Categories.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20190920120115_AddMoreInitialData")]
    partial class AddMoreInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("API_2019_09_20_ToDo_With_Categories.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new { CategoryId = 1, CategoryName = "work" },
                        new { CategoryId = 2, CategoryName = "leisure" }
                    );
                });

            modelBuilder.Entity("API_2019_09_20_ToDo_With_Categories.ToDoList", b =>
                {
                    b.Property<int>("ToDoListId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateDone");

                    b.Property<bool>("Done");

                    b.Property<string>("ToDoItem");

                    b.HasKey("ToDoListId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new { ToDoListId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = false, ToDoItem = "To Do" },
                        new { ToDoListId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = false, ToDoItem = "To Do Also" },
                        new { ToDoListId = 3, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = false, ToDoItem = "Then To Do" },
                        new { ToDoListId = 4, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = true, ToDoItem = "To Do This Also" },
                        new { ToDoListId = 5, CategoryId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = true, ToDoItem = "To Do This Also" },
                        new { ToDoListId = 6, CategoryId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = true, ToDoItem = "To Do This Also" },
                        new { ToDoListId = 7, CategoryId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = true, ToDoItem = "To Do This Sometimes" },
                        new { ToDoListId = 8, CategoryId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateDone = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Done = false, ToDoItem = "To Do This Whenever" }
                    );
                });

            modelBuilder.Entity("API_2019_09_20_ToDo_With_Categories.ToDoList", b =>
                {
                    b.HasOne("API_2019_09_20_ToDo_With_Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
