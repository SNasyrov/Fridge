using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeV2.Migrations
{
    public partial class ProductInFridge_Add_SaveToShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SaveToList",
                table: "ProductsInFridge",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveToList",
                table: "ProductsInFridge");
        }
    }
}
