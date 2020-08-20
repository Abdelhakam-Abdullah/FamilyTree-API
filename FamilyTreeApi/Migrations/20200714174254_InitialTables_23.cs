using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "UserNotification",
                newName: "NewsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateH",
                table: "UserNotification",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateM",
                table: "UserNotification",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "UserNotification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "UserNotification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NotifyName",
                table: "UserNotification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotifyType",
                table: "UserNotification",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDateH",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "AddDateM",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "NotifyName",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "NotifyType",
                table: "UserNotification");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "UserNotification",
                newName: "NotificationId");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDateH = table.Column<DateTime>(type: "date", nullable: false),
                    AddDateM = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
                    NotifyName = table.Column<string>(nullable: true),
                    NotifyType = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateH = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedDateM = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    NotifyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
