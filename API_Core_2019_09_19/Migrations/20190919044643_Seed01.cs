using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_19_API_Core_From_Scratch.Migrations
{
    public partial class Seed01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "ToDoId", "ToDoDone", "ToDoItem" },
                values: new object[] { 1L, false, "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "ToDoId",
                keyValue: 1L);
        }
    }
}
