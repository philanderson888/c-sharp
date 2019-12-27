using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_FamilyApp_2019_11_02_Core_SQL.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyLogs",
                columns: table => new
                {
                    DailyLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyLogDate = table.Column<DateTime>(nullable: false),
                    UpOnTime = table.Column<bool>(nullable: true),
                    StayedUp = table.Column<bool>(nullable: true),
                    MadeGym = table.Column<bool>(nullable: true),
                    PrWithFam = table.Column<bool>(nullable: true),
                    PrWthZ = table.Column<bool>(nullable: true),
                    CrsPryPhoto = table.Column<bool>(nullable: true),
                    PhilPryPhoto = table.Column<bool>(nullable: true),
                    CrsDeskPhoto = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogs", x => x.DailyLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyLogs");
        }
    }
}
