using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Model_RecipeList_Add_User_And_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RecipesLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipesLists_UserId",
                table: "RecipesLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLists_AspNetUsers_UserId",
                table: "RecipesLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLists_AspNetUsers_UserId",
                table: "RecipesLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipesLists_UserId",
                table: "RecipesLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecipesLists");
        }
    }
}
