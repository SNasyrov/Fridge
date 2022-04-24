using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Model_ProductInTheRecipe_Add_RecipeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "ProductInTheRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "ProductInTheRecipes");
        }
    }
}
