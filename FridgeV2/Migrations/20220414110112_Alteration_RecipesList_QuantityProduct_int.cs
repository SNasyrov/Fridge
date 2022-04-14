using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Alteration_RecipesList_QuantityProduct_int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantityProduct",
                table: "RecipesLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "QuantityProduct",
                table: "RecipesLists",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
