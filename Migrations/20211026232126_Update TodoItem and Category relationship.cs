using Microsoft.EntityFrameworkCore.Migrations;

namespace just_todo_list_api.Migrations
{
    public partial class UpdateTodoItemandCategoryrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Categories_CategoryId",
                table: "TodoItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Categories_CategoryId",
                table: "TodoItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Categories_CategoryId",
                table: "TodoItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Categories_CategoryId",
                table: "TodoItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
