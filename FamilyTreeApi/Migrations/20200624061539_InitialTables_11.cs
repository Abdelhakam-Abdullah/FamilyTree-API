using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Blog",
                nullable: false,
                defaultValue: false);
        }
    }
}
