using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Model_RecipeList_Delete_CommentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdId",
                table: "RecipesLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipesLists_CommentsIdId",
                table: "RecipesLists");

            migrationBuilder.DropColumn(
                name: "CommentsIdId",
                table: "RecipesLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentsIdId",
                table: "RecipesLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipesLists_CommentsIdId",
                table: "RecipesLists",
                column: "CommentsIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdId",
                table: "RecipesLists",
                column: "CommentsIdId",
                principalTable: "CommentsUnderRecipes",
                principalColumn: "Id");
        }
    }
}
