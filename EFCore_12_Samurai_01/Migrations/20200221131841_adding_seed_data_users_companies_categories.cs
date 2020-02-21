using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_12_Samurai_01.Migrations
{
    public partial class adding_seed_data_users_companies_categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Sparta" },
                    { 2, "BBC" },
                    { 3, "ITV" }
                });

            migrationBuilder.InsertData(
                table: "SubItems",
                columns: new[] { "SubItemId", "SubItemName" },
                values: new object[] { 1, "some sub item name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CategoryId", "CompanyId", "UserName" },
                values: new object[] { 1, 1, 1, "Bob" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CategoryId", "CompanyId", "UserName" },
                values: new object[] { 2, 2, 2, "Tim" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CategoryId", "CompanyId", "UserName" },
                values: new object[] { 3, 3, 3, "Joe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubItems",
                keyColumn: "SubItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);
        }
    }
}
