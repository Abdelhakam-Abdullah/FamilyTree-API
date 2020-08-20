using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReqStatus = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_RequestStatus_RequestStatusId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_News_RequestStatus_RequestStatusId",
                table: "News");

            migrationBuilder.DropTable(
                name: "RequestStatus");

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
        }
    }
}
