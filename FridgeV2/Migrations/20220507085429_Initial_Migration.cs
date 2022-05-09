using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityProduct",
                table: "RecipesLists");

            migrationBuilder.DropColumn(
                name: "SaveToList",
                table: "ProductsInFridge");

            migrationBuilder.DropColumn(
                name: "LikeTheProduct",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityProduct",
                table: "RecipesLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SaveToList",
                table: "ProductsInFridge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikeTheProduct",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
