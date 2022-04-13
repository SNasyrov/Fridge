using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Alteration_FavoriteProduct_ProductName_and_ManufacturerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "FavoriteProducts",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "FavoriteProducts",
                newName: "ManufacturerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "FavoriteProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ManufacturerName",
                table: "FavoriteProducts",
                newName: "ManufacturerId");
        }
    }
}
