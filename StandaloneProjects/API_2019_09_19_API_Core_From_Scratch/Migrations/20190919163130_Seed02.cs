using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_19_API_Core_From_Scratch.Migrations
{
    public partial class Seed02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "ToDoDone", "ToDoItem" },
                values: new object[] { 2L, false, "DoThis" });

            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "ToDoDone", "ToDoItem" },
                values: new object[] { 3L, true, "Do That" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 3L);
        }
    }
}
