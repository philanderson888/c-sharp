using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyApp_01.Data.Migrations
{
    public partial class initial04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Category_CategoryId",
                table: "TaskItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TaskItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Category_CategoryId",
                table: "TaskItems",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Category_CategoryId",
                table: "TaskItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TaskItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Category_CategoryId",
                table: "TaskItems",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
