﻿// <auto-generated />
using System;
using FamilyTreeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyTreeApi.Migrations
{
    [DbContext(typeof(FamilyTreeContext))]
    [Migration("20200701200704_InitialTables_20")]
    partial class InitialTables_20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyTreeApi.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowComment");

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.BlogComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogComment");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.DefinitionLineage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TreeDefinition");

                    b.HasKey("Id");

                    b.ToTable("DefinitionLineage");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FamilyName");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Symbole");

                    b.HasKey("Id");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.FamilyCharacters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharId");

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CharId")
                        .IsUnique()
                        .HasFilter("[CharId] IS NOT NULL");

                    b.ToTable("FamilyCharacters");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowComment");

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<string>("Desctiption");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("NewsPlace");

                    b.Property<int>("NewsTypeId");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NewsTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NewsComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("NewsId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("NewsComment");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NewsImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("IsMain");

                    b.Property<int>("NewsId");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsImage");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NewsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("NewsType1");

                    b.HasKey("Id");

                    b.ToTable("NewsType");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("AddDateM")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("NotificationTypeId");

                    b.Property<string>("NotifyName");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("NotifyType");

                    b.HasKey("Id");

                    b.ToTable("NotificationType");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("ReqStatus");

                    b.HasKey("Id");

                    b.ToTable("RequestStatus");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppLogo");

                    b.Property<string>("AppName");

                    b.Property<string>("CPanelLogo");

                    b.Property<string>("LoginLogo");

                    b.Property<string>("MailAddress");

                    b.Property<string>("MailPassword");

                    b.Property<string>("MailServer");

                    b.Property<int>("MailServerPort");

                    b.Property<string>("MailUserName");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Terms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Termss");

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptedAdd");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<bool>("AllowAddChildren");

                    b.Property<bool>("AllowAddFamilyChar");

                    b.Property<bool>("AllowBlog");

                    b.Property<bool>("AllowNews");

                    b.Property<DateTime?>("BirthDateH")
                        .HasColumnType("date");

                    b.Property<DateTime?>("BirthDateM")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDateH")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDateM")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FaceBookAcc");

                    b.Property<int>("FamilyId");

                    b.Property<string>("FullName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("IdentityNumber");

                    b.Property<string>("Image");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("JobTitle");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int?>("MotherId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int?>("ParentId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("StatusId");

                    b.Property<string>("TwitterAcc");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int?>("UserStatusId");

                    b.Property<int>("UserTypeId");

                    b.Property<string>("WorkAddress");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserStatusId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NotificationId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotification");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("UType");

                    b.HasKey("Id");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Wife", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("UserId");

                    b.Property<string>("WName");

                    b.HasKey("Id");

                    b.ToTable("Wife");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Blog", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.User", "User")
                        .WithMany("Blog")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.BlogComment", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.Blog", "Blog")
                        .WithMany("BlogComment")
                        .HasForeignKey("BlogId");

                    b.HasOne("FamilyTreeApi.Models.User", "User")
                        .WithMany("BlogComment")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.FamilyCharacters", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.User", "UserChar")
                        .WithOne("FamilyCharactersUser")
                        .HasForeignKey("FamilyTreeApi.Models.FamilyCharacters", "CharId");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.News", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.NewsType", "NewsType")
                        .WithMany("News")
                        .HasForeignKey("NewsTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FamilyTreeApi.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NewsComment", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.News", "News")
                        .WithMany("NewsComment")
                        .HasForeignKey("NewsId");

                    b.HasOne("FamilyTreeApi.Models.User", "User")
                        .WithMany("NewsComment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.NewsImage", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.News", "News")
                        .WithMany("NewsImage")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.Notification", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.NotificationType", "NotificationType")
                        .WithMany("Notification")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.RoleClaim", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.User", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("FamilyTreeApi.Models.User", "Parent")
                        .WithMany("UserChild")
                        .HasForeignKey("ParentId");

                    b.HasOne("FamilyTreeApi.Models.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId");

                    b.HasOne("FamilyTreeApi.Models.UserType", "UserType")
                        .WithMany("User")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserClaim", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserLogin", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserNotification", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.Notification", "Notification")
                        .WithMany("UserNotification")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FamilyTreeApi.Models.User", "User")
                        .WithMany("UserNotification")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserRole", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FamilyTreeApi.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FamilyTreeApi.Models.UserToken", b =>
                {
                    b.HasOne("FamilyTreeApi.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
