using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_RequestStatus_RequestStatusId",
                table: "News");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropIndex(
                name: "IX_News_RequestStatusId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<bool>(nullable: false),
                    ReqStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_RequestStatusId",
                table: "News",
                column: "RequestStatusId");

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
