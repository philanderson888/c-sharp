using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Core_FamilyApp_2019_10_12_Sqlite.Migrations
{
    public partial class initial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadDailyItems",
                columns: table => new
                {
                    DadDailyItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TodaysDate = table.Column<DateTime>(nullable: false),
                    UpOnTime = table.Column<bool>(nullable: false),
                    GetEarlyTrain = table.Column<bool>(nullable: false),
                    CallPhilip550 = table.Column<bool>(nullable: false),
                    CallChrista550 = table.Column<bool>(nullable: false),
                    WorkAtFinsburyPark = table.Column<bool>(nullable: false),
                    HitTheGym = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadDailyItems", x => x.DadDailyItemId);
                });

            migrationBuilder.InsertData(
                table: "DadDailyItems",
                columns: new[] { "DadDailyItemId", "CallChrista550", "CallPhilip550", "GetEarlyTrain", "HitTheGym", "TodaysDate", "UpOnTime", "WorkAtFinsburyPark" },
                values: new object[] { 1, false, false, false, false, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadDailyItems");
        }
    }
}
