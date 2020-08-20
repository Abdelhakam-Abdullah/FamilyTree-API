using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_RequestStatus_RequestStatusId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_News_RequestStatus_RequestStatusId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_RequestStatusId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Blog_RequestStatusId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Blog");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "News",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Blog");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "News",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_RequestStatusId",
                table: "News",
                column: "RequestStatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_News_RequestStatus_RequestStatusId",
                table: "News",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
