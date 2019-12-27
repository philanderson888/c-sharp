using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_FamilyApp_2019_11_02_Core_SQL.Data.Migrations
{
    public partial class addingnbrsns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "NbrSns",
                table: "DailyLogs",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbrSns",
                table: "DailyLogs");
        }
    }
}
