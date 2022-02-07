using Microsoft.EntityFrameworkCore.Migrations;

namespace WTechECommerce.Data.Migrations
{
    public partial class AdminUserTableRoleColumnCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AdminUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AdminUsers");
        }
    }
}
