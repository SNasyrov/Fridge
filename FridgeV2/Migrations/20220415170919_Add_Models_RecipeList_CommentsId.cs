using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Add_Models_RecipeList_CommentsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentsIdid",
                table: "RecipesLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipesLists_CommentsIdid",
                table: "RecipesLists",
                column: "CommentsIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdid",
                table: "RecipesLists",
                column: "CommentsIdid",
                principalTable: "CommentsUnderRecipes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdid",
                table: "RecipesLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipesLists_CommentsIdid",
                table: "RecipesLists");

            migrationBuilder.DropColumn(
                name: "CommentsIdid",
                table: "RecipesLists");
        }
    }
}
