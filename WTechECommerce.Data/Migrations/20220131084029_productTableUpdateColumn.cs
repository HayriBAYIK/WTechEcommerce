using Microsoft.EntityFrameworkCore.Migrations;

namespace WTechECommerce.Data.Migrations
{
    public partial class productTableUpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImgPath",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImgPath",
                table: "Products");
        }
    }
}
