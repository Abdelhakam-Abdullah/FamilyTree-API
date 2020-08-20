using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTreeApi.Migrations
{
    public partial class InitialTables_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "BlogComment",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "AddNewsCommentDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NewsPlace = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    NewsTypeId = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
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
                    Image = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: true),
                    AllowComment = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false)
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
                    FullName = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
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
                    Title = table.Column<string>(nullable: true),
                    CharName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: true),
                    CreatedDateH = table.Column<DateTime>(nullable: true)
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
                    FullName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
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
                    FullName = table.Column<string>(nullable: true),
                    AddDateM = table.Column<DateTime>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetUsersDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyBlogDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false)
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
                    UserImage = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Desctiption = table.Column<string>(nullable: true),
                    NewsType = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Desctiption = table.Column<string>(nullable: true),
                    NewsType = table.Column<string>(nullable: true),
                    NewsImage = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NewsTypeId = table.Column<int>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false)
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
                    Title = table.Column<string>(nullable: true),
                    Desctiption = table.Column<string>(nullable: true),
                    ByUser = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDateM = table.Column<DateTime>(nullable: false),
                    CreatedDateH = table.Column<DateTime>(nullable: false),
                    AllowAddNews = table.Column<bool>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    NewsType = table.Column<string>(nullable: true)
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
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
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
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true)
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
                    IdentityNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AcceptedAdd = table.Column<bool>(nullable: false)
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
                    UserImage = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    IsAddChild = table.Column<bool>(nullable: false),
                    IsAddFamilyChar = table.Column<bool>(nullable: false),
                    IsAddBlogs = table.Column<bool>(nullable: false),
                    IsAddNews = table.Column<bool>(nullable: false)
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
                    IsAddChild = table.Column<bool>(nullable: false),
                    IsAddFamilyChar = table.Column<bool>(nullable: false),
                    IsAddBlogs = table.Column<bool>(nullable: false),
                    IsAddNews = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionUpdateDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true),
                    FaceBookAcc = table.Column<string>(nullable: true),
                    TwitterAcc = table.Column<string>(nullable: true),
                    AllowAddChildren = table.Column<bool>(nullable: true),
                    AllowAddFamilyChar = table.Column<bool>(nullable: true),
                    AllowNews = table.Column<bool>(nullable: true),
                    AllowBlog = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
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
                    IdentityNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true),
                    FaceBookAcc = table.Column<string>(nullable: true),
                    TwitterAcc = table.Column<string>(nullable: true),
                    AcceptedAdd = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
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
                    IdentityNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    BirthDateM = table.Column<DateTime>(nullable: true),
                    BirthDateH = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true),
                    FaceBookAcc = table.Column<string>(nullable: true),
                    TwitterAcc = table.Column<string>(nullable: true),
                    AllowAddChildren = table.Column<bool>(nullable: true),
                    AllowAddFamilyChar = table.Column<bool>(nullable: true),
                    AllowNews = table.Column<bool>(nullable: true),
                    AllowBlog = table.Column<bool>(nullable: true)
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
                    WifeName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifeDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ImagesDTO");

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
                name: "UserProfileDTO");

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

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "BlogComment",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
