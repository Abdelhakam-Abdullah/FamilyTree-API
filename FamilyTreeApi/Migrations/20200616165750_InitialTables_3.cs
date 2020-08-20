using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddNewsCommentDTO");

            migrationBuilder.DropTable(
                name: "AddNewsDTO");

            migrationBuilder.DropTable(
                name: "BlodCommentsDTO");

            migrationBuilder.DropTable(
                name: "BlogDetailsDTO");

            migrationBuilder.DropTable(
                name: "BlogMDTO");

            migrationBuilder.DropTable(
                name: "BlogsDetailsDTO");

            migrationBuilder.DropTable(
                name: "BlogsDTO");

            migrationBuilder.DropTable(
                name: "BlogsUserDTO");

            migrationBuilder.DropTable(
                name: "FamilyCharacterDetailsDTO");

            migrationBuilder.DropTable(
                name: "FamilyCharactersAdminDTO");

            migrationBuilder.DropTable(
                name: "FamilyCharactersDTO");

            migrationBuilder.DropTable(
                name: "FamilyCharUpdateDTO");

            migrationBuilder.DropTable(
                name: "FamilyDTO");

            migrationBuilder.DropTable(
                name: "FamilyTreeDTO");

            migrationBuilder.DropTable(
                name: "FilterUserPermissionDTO");

            migrationBuilder.DropTable(
                name: "GetUsersDTO");

            migrationBuilder.DropTable(
                name: "MyBlogDTO");

            migrationBuilder.DropTable(
                name: "NewsCommentDTO");

            migrationBuilder.DropTable(
                name: "NewsDetailsDTO");

            migrationBuilder.DropTable(
                name: "NewsDTO");

            migrationBuilder.DropTable(
                name: "NewsEditDTO");

            migrationBuilder.DropTable(
                name: "NewsImagesDTO");

            migrationBuilder.DropTable(
                name: "NewsImagesEditDTO");

            migrationBuilder.DropTable(
                name: "NewsListDTO");

            migrationBuilder.DropTable(
                name: "NewsTypeDTO");

            migrationBuilder.DropTable(
                name: "TestDTO");

            migrationBuilder.DropTable(
                name: "UserDTO");

            migrationBuilder.DropTable(
                name: "UserFilterDTO");

            migrationBuilder.DropTable(
                name: "UserIdentityDTO");

            migrationBuilder.DropTable(
                name: "UserPermissionDTO");

            migrationBuilder.DropTable(
                name: "UserPermissionUpdateDTO");

            migrationBuilder.DropTable(
                name: "UserRelationDTO");

            migrationBuilder.DropTable(
                name: "UserReturnDTO");

            migrationBuilder.DropTable(
                name: "UserToReturnDTO");

            migrationBuilder.DropTable(
                name: "UtilitiesDTO");

            migrationBuilder.DropTable(
                name: "WifeDTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddNewsCommentDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNewsCommentDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddNewsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    NewsPlace = table.Column<string>(nullable: true),
                    NewsTypeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNewsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlodCommentsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlodCommentsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogDetailsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetailsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogMDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogMDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogsDetailsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsDetailsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogsUserDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsUserDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCharacterDetailsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCharacterDetailsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCharactersAdminDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedBy = table.Column<string>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    CharName = table.Column<string>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCharactersAdminDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCharactersDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCharactersDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCharUpdateDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCharUpdateDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamilyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyTreeDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    ParenName = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterUserPermissionDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchBy = table.Column<string>(nullable: true),
                    SearckKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterUserPermissionDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetUsersDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDateM = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetUsersDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyBlogDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBlogDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsCommentDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    UserImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCommentDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsDetailsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Desctiption = table.Column<string>(nullable: true),
                    NewsType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDetailsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Desctiption = table.Column<string>(nullable: true),
                    NewsImage = table.Column<string>(nullable: true),
                    NewsType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsEditDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowComment = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    NewsTypeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsEditDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsImagesDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImagesDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsImagesEditDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    NewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImagesEditDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsListDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowAddNews = table.Column<bool>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    Desctiption = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    NewsType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsListDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsTypeDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTypeDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFilterDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilterDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentityDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptedAdd = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentityDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    IsAddBlogs = table.Column<bool>(nullable: false),
                    IsAddChild = table.Column<bool>(nullable: false),
                    IsAddFamilyChar = table.Column<bool>(nullable: false),
                    IsAddNews = table.Column<bool>(nullable: false),
                    UserImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionUpdateDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAddBlogs = table.Column<bool>(nullable: false),
                    IsAddChild = table.Column<bool>(nullable: false),
                    IsAddFamilyChar = table.Column<bool>(nullable: false),
                    IsAddNews = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionUpdateDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelationDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReturnDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptedAdd = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FaceBookAcc = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TwitterAcc = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReturnDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToReturnDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AllowAddChildren = table.Column<bool>(nullable: true),
                    AllowAddFamilyChar = table.Column<bool>(nullable: true),
                    AllowBlog = table.Column<bool>(nullable: true),
                    AllowNews = table.Column<bool>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FaceBookAcc = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TwitterAcc = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToReturnDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogsCount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WifeDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    WifeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifeDTO", x => x.Id);
                });
        }
    }
}
