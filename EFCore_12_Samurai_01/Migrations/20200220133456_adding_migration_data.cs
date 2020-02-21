using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_12_Samurai_01.Migrations
{
    public partial class adding_migration_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FirstModels",
                columns: new[] { "FirstModelId", "FirstModelName" },
                values: new object[] { 1, "test one" });

            migrationBuilder.InsertData(
                table: "FirstModels",
                columns: new[] { "FirstModelId", "FirstModelName" },
                values: new object[] { 2, "test two" });

            migrationBuilder.InsertData(
                table: "FirstModels",
                columns: new[] { "FirstModelId", "FirstModelName" },
                values: new object[] { 3, "test three" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FirstModels",
                keyColumn: "FirstModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FirstModels",
                keyColumn: "FirstModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FirstModels",
                keyColumn: "FirstModelId",
                keyValue: 3);
        }
    }
}
