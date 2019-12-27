﻿// <auto-generated />
using System;
using MVC_2019_03_FluentAPI_02;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_2019_03_FluentAPI_02.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20190903200359_initial4")]
    partial class initial4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_2019_03_FluentAPI_02.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToDoItem");

                    b.Property<int?>("UserId");

                    b.HasKey("ToDoId");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoes");
                });

            modelBuilder.Entity("MVC_2019_03_FluentAPI_02.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MVC_2019_03_FluentAPI_02.ToDo", b =>
                {
                    b.HasOne("MVC_2019_03_FluentAPI_02.User", "User")
                        .WithMany("ToDoes")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
