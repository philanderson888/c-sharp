using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_20.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "Done", "ToDoItem" },
                values: new object[] { 1, false, "To Do" });

            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "Done", "ToDoItem" },
                values: new object[] { 2, false, "Also To Do" });

            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "Done", "ToDoItem" },
                values: new object[] { 3, false, "And To Do" });

            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "Done", "ToDoItem" },
                values: new object[] { 4, true, "Then To Do" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 4);
        }
    }
}
