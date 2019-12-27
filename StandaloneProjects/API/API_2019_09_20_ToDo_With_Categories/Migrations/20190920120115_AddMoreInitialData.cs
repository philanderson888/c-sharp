using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_20_ToDo_With_Categories.Migrations
{
    public partial class AddMoreInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "To Do This Sometimes" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "CategoryId", "DateCreated", "DateDone", "Done", "ToDoItem" },
                values: new object[] { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "To Do This Whenever" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: 8);
        }
    }
}
