using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Test_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInTheRecipes_Products_ProductId1",
                table: "ProductInTheRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductInTheRecipes_ProductId1",
                table: "ProductInTheRecipes");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductInTheRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductInTheRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInTheRecipes_ProductId",
                table: "ProductInTheRecipes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInTheRecipes_Products_ProductId",
                table: "ProductInTheRecipes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInTheRecipes_Products_ProductId",
                table: "ProductInTheRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductInTheRecipes_ProductId",
                table: "ProductInTheRecipes");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductInTheRecipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductInTheRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInTheRecipes_ProductId1",
                table: "ProductInTheRecipes",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInTheRecipes_Products_ProductId1",
                table: "ProductInTheRecipes",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
