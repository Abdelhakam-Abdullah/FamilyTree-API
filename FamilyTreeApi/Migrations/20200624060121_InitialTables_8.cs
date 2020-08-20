using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_RequestStatus_RequestStatusId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_RequestStatusId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_RequestStatusId",
                table: "Blog",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_RequestStatus_RequestStatusId",
                table: "Blog",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
