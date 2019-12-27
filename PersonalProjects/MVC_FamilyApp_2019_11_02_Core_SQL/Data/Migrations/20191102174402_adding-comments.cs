using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_FamilyApp_2019_11_02_Core_SQL.Data.Migrations
{
    public partial class addingcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UpOnTime",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "StayedUp",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PrWthZ",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PrWithFam",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PhilPryPhoto",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MadeGym",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CrsPryPhoto",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CrsDeskPhoto",
                table: "DailyLogs",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "DailyLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "DailyLogs");

            migrationBuilder.AlterColumn<bool>(
                name: "UpOnTime",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "StayedUp",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "PrWthZ",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "PrWithFam",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "PhilPryPhoto",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "MadeGym",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "CrsPryPhoto",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "CrsDeskPhoto",
                table: "DailyLogs",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
