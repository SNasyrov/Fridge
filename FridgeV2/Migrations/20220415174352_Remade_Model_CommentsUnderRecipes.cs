using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Remade_Model_CommentsUnderRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdid",
                table: "RecipesLists");

            migrationBuilder.RenameColumn(
                name: "CommentsIdid",
                table: "RecipesLists",
                newName: "CommentsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipesLists_CommentsIdid",
                table: "RecipesLists",
                newName: "IX_RecipesLists_CommentsIdId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CommentsUnderRecipes",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdId",
                table: "RecipesLists",
                column: "CommentsIdId",
                principalTable: "CommentsUnderRecipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdId",
                table: "RecipesLists");

            migrationBuilder.RenameColumn(
                name: "CommentsIdId",
                table: "RecipesLists",
                newName: "CommentsIdid");

            migrationBuilder.RenameIndex(
                name: "IX_RecipesLists_CommentsIdId",
                table: "RecipesLists",
                newName: "IX_RecipesLists_CommentsIdid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommentsUnderRecipes",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesLists_CommentsUnderRecipes_CommentsIdid",
                table: "RecipesLists",
                column: "CommentsIdid",
                principalTable: "CommentsUnderRecipes",
                principalColumn: "id");
        }
    }
}
