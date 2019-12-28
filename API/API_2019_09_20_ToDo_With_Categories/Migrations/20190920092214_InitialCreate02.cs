using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_20_ToDo_With_Categories.Migrations
{
    public partial class InitialCreate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoListId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToDoItem = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDone = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoListId);
                    table.ForeignKey(
                        name: "FK_ToDoLists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "leisure" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "To Do" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "To Do Also" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Then To Do" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "To Do This Also" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "To Do This Also" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "To Do This Also" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_CategoryId",
                table: "ToDoLists",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
