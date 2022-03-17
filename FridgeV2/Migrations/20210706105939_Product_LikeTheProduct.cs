using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeV2.Migrations
{
    public partial class Product_LikeTheProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LikeTheProduct",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeTheProduct",
                table: "Products");
        }
    }
}
