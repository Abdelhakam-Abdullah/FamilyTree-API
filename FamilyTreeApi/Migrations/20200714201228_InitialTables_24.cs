using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Allow_GeneralNews",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Allow_Mawaled",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Allow_Monasaba",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Allow_Wafeaat",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allow_GeneralNews",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Allow_Mawaled",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Allow_Monasaba",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Allow_Wafeaat",
                table: "User");
        }
    }
}
