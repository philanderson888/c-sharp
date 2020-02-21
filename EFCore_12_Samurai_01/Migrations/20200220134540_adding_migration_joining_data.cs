using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_12_Samurai_01.Migrations
{
    public partial class adding_migration_joining_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JoiningTable",
                columns: new[] { "FirstModelId", "SecondModelId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "JoiningTable",
                columns: new[] { "FirstModelId", "SecondModelId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "JoiningTable",
                columns: new[] { "FirstModelId", "SecondModelId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JoiningTable",
                keyColumns: new[] { "FirstModelId", "SecondModelId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "JoiningTable",
                keyColumns: new[] { "FirstModelId", "SecondModelId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "JoiningTable",
                keyColumns: new[] { "FirstModelId", "SecondModelId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
