using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_MVC_Core_Movie_05.Migrations
{
    public partial class updateprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movie",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movie");
        }
    }
}
