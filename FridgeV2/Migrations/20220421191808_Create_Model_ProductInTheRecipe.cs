using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Create_Model_ProductInTheRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductInTheRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInTheRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInTheRecipes_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInTheRecipes_ProductId1",
                table: "ProductInTheRecipes",
                column: "ProductId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInTheRecipes");
        }
    }
}
