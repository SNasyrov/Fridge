using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeV2.Migrations
{
    public partial class Add_Model_GeneralFridge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralFridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(type: "int", nullable: false),
                    ProductInFridgeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralFridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralFridges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralFridges_ProductsInFridge_ProductInFridgeId",
                        column: x => x.ProductInFridgeId,
                        principalTable: "ProductsInFridge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralFridges_ProductInFridgeId",
                table: "GeneralFridges",
                column: "ProductInFridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralFridges_UserId",
                table: "GeneralFridges",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralFridges");
        }
    }
}
