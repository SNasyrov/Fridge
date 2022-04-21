using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Rework_Model_HowToCook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "HowToCook",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RecipeListId",
                table: "HowToCook",
                newName: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HowToCook",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "HowToCook",
                newName: "RecipeListId");
        }
    }
}
