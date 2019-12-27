using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2019_09_19_API_Core_From_Scratch.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoes",
                columns: table => new
                {
                    ToDoId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToDoItem = table.Column<string>(nullable: true),
                    ToDoDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoes", x => x.ToDoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoes");
        }
    }
}
