using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyRequests = table.Column<bool>(nullable: false),
                    ViewPages = table.Column<bool>(nullable: false),
                    EditPages = table.Column<bool>(nullable: false),
                    DeletePages = table.Column<bool>(nullable: false),
                    AddPages = table.Column<bool>(nullable: false),
                    ApprovalRejectionRequests = table.Column<bool>(nullable: false),
                    GivingPermissionForUsers = table.Column<bool>(nullable: false),
                    CreateSuperAdmin = table.Column<bool>(nullable: false),
                    DeleteFromFamilyTree = table.Column<bool>(nullable: false),
                    DeleteRequrest = table.Column<bool>(nullable: false),
                    BlockRequests = table.Column<bool>(nullable: false),
                    GivinPermission = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");
        }
    }
}
