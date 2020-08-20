using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data
{
    public class FamilyTreeContext : IdentityDbContext<User, Role, int,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public IConfiguration _configuration { get; }
        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();

            string conString = _configuration.GetConnectionString("FamilyTreeConnection");
            optionsBuilder.UseSqlServer(conString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region custome table name
            modelBuilder.Entity<User>()
              .ToTable("User");

            modelBuilder.Entity<Role>()
                .ToTable("Role");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRole");

            modelBuilder.Entity<UserClaim>()
                .ToTable("UserClaim");

            modelBuilder.Entity<UserLogin>()
                .ToTable("UserLogin");

            modelBuilder.Entity<RoleClaim>()
              .ToTable("RoleClaim");

            modelBuilder.Entity<UserToken>()
            .ToTable("UserToken");
            #endregion

            #region relations config
            //****************** /Configuration relationship/ ***************************************
            //user & FamilyCharacters(1 to 1)
            modelBuilder.Entity<User>()
                .HasOne(s => s.FamilyCharactersUser)
                .WithOne(fc => fc.UserChar)
                .HasForeignKey<FamilyCharacters>(ad => ad.CharId);

            //user & user(self relation)
            modelBuilder.Entity<User>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.UserChild)
                        .HasForeignKey(x => x.ParentId);

            // configures one-to-many relationship
            //modelBuilder.Entity<Family>()
            //    .HasMany(f => f.User)
            //    .WithOne()
            //    .HasForeignKey(a => a.FamilyId);



            modelBuilder.Entity<User>()
                 .Property(b => b.BirthDateM)
                 .HasColumnType("date");

            modelBuilder.Entity<User>()
                .Property(b => b.BirthDateH)
                .HasColumnType("date");

            modelBuilder.Entity<User>()
               .Property(b => b.CreatedDateM)
               .HasColumnType("datetime");

            modelBuilder.Entity<User>()
                .Property(b => b.CreatedDateH)
                .HasColumnType("date");

            modelBuilder.Entity<News>()
                .Property(b => b.CreatedDateM)
                .HasColumnType("datetime");               

            modelBuilder.Entity<News>()
              .Property(b => b.CreatedDateH)
              .HasColumnType("date");

            modelBuilder.Entity<Blog>()
              .Property(b => b.CreatedDateM)
              .HasColumnType("datetime");

            modelBuilder.Entity<Blog>()
            .Property(b => b.CreatedDateH)
            .HasColumnType("date");

            modelBuilder.Entity<BlogComment>()
               .Property(b => b.CreatedDateM)
               .HasColumnType("datetime");

            modelBuilder.Entity<BlogComment>()
             .Property(b => b.CreatedDateH)
             .HasColumnType("date");

            modelBuilder.Entity<FamilyCharacters>()
            .Property(b => b.CreatedDateM)
            .HasColumnType("datetime");

            modelBuilder.Entity<FamilyCharacters>()
           .Property(b => b.CreatedDateH)
           .HasColumnType("date");

            modelBuilder.Entity<NewsComment>()
               .Property(b => b.CreatedDateM)
               .HasColumnType("datetime");

            modelBuilder.Entity<NewsComment>()
              .Property(b => b.CreatedDateH)
              .HasColumnType("date");

            modelBuilder.Entity<NewsImage>()
             .Property(b => b.CreatedDateM)
             .HasColumnType("datetime");

            modelBuilder.Entity<NewsImage>()
              .Property(b => b.CreatedDateH)
              .HasColumnType("date");

            modelBuilder.Entity<UserNotification>()
            .Property(b => b.AddDateM)
            .HasColumnType("datetime");

            modelBuilder.Entity<UserNotification>()
              .Property(b => b.AddDateH)
              .HasColumnType("date");
            #endregion

            #region Ignores
            //modelBuilder.Ignore<UserDTO>();
            //modelBuilder.Ignore<UserIdentityDTO>();
            //modelBuilder.Ignore<FamilyCharactersDTO>();
            //modelBuilder.Ignore<FamilyCharAddDTO>();
            //modelBuilder.Ignore<UserCompleteRegisterDTO>();
            //modelBuilder.Ignore<UserLoginDTO>();
            //modelBuilder.Ignore<UserRegisterDTO>();
            //modelBuilder.Ignore<UserToReturnDTO>();
            //modelBuilder.Ignore<UserUpdatePassDTO>();
            //modelBuilder.Ignore<UserUpdateProfileDTO>();
            //modelBuilder.Ignore<FamilyCharacterDetailsDTO>();
            //modelBuilder.Ignore<UserFilterDTO>();
            //modelBuilder.Ignore<FamilyDTO>();
            //modelBuilder.Ignore<BlogsDTO>();
            //modelBuilder.Ignore<BlodCommentsDTO>();
            //modelBuilder.Ignore<BlogsUserDTO>();
            //modelBuilder.Ignore<NewsDTO>();
            //modelBuilder.Ignore<NewsDetailsDTO>();
            //modelBuilder.Ignore<NewsImagesDTO>();
            //modelBuilder.Ignore<AddNewsDTO>();
            //modelBuilder.Ignore<NewsCommentDTO>();
            //modelBuilder.Ignore<AddNewsCommentDTO>();
            //modelBuilder.Ignore<GetUsersDTO>();
            //modelBuilder.Ignore<NewsTypeDTO>();
            //modelBuilder.Ignore<UtilitiesDTO>();
            //modelBuilder.Ignore<FamilyCharactersAdminDTO>();
            //modelBuilder.Ignore<FamilyCharUpdateDTO>();
            //modelBuilder.Ignore<UserPermissionDTO>();
            //modelBuilder.Ignore<UserPermissionUpdateDTO>();
            //modelBuilder.Ignore<FilterUserPermissionDTO>();
            //modelBuilder.Ignore<FamilyTreeDTO>();
            //modelBuilder.Ignore<NewsListDTO>();
            //modelBuilder.Ignore<UserRelationDTO>();
            //modelBuilder.Ignore<WifeDTO>();
            //modelBuilder.Ignore<BlogsDetailsDTO>();
            //modelBuilder.Ignore<MyBlogDTO>();
            //modelBuilder.Ignore<BlogDetailsDTO>();
            //modelBuilder.Ignore<UserReturnDTO>();
            //modelBuilder.Ignore<BlogMDTO>();
            //modelBuilder.Ignore<NewsEditDTO>();
            //modelBuilder.Ignore<NewsImagesEditDTO>();
            //modelBuilder.Ignore<UserProfileDTO>();
            //modelBuilder.Ignore<ImagesDTO>();
            //modelBuilder.Ignore<FamilyCharactersSearchDTO>();
            //modelBuilder.Ignore<UserInfoDTO>();
            //modelBuilder.Ignore<UpdateUserLoginDataDTO>();
            //modelBuilder.Ignore<AddBlogDTO>();
            //modelBuilder.Ignore<NewsAddedDTO>();
            //modelBuilder.Ignore<UserProfileDataDTO>();
            //modelBuilder.Ignore<UserNotificationsDTO>();
            //modelBuilder.Ignore<NewsDetailsAdminDTO>();
            //modelBuilder.Ignore<UserParentsDTO>();

            #endregion
        }

        #region custome dbset
        [NotMapped]
        public DbSet<UserDTO> UserDTO { get; set; }
        [NotMapped]
        public DbSet<UserIdentityDTO> UserIdentityDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyCharactersDTO> FamilyCharactersDTO { get; set; }
        [NotMapped]
        public DbSet<UserFilterDTO> UserFilterDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyCharacterDetailsDTO> FamilyCharacterDetailsDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyDTO> FamilyDTO { get; set; }
        [NotMapped]
        public DbSet<BlogsDTO> BlogsDTO { get; set; }
        [NotMapped]
        public DbSet<BlodCommentsDTO> BlodCommentsDTO { get; set; }
        [NotMapped]
        public DbSet<BlogsUserDTO> BlogsUserDTO { get; set; }
        [NotMapped]
        public DbSet<NewsDTO> NewsDTO { get; set; }
        [NotMapped]
        public DbSet<NewsDetailsDTO> NewsDetailsDTO { get; set; }
        [NotMapped]
        public DbSet<NewsImagesDTO> NewsImagesDTO { get; set; }
        [NotMapped]
        public DbSet<AddNewsDTO> AddNewsDTO { get; set; }
        [NotMapped]
        public DbSet<NewsCommentDTO> NewsCommentDTO { get; set; }
        [NotMapped]
        public DbSet<AddNewsCommentDTO> AddNewsCommentDTO { get; set; }
        [NotMapped]
        public DbSet<GetUsersDTO> GetUsersDTO { get; set; }
        [NotMapped]
        public DbSet<NewsTypeDTO> NewsTypeDTO { get; set; }
        [NotMapped]
        public DbSet<UtilitiesDTO> UtilitiesDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyCharactersAdminDTO> FamilyCharactersAdminDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyCharUpdateDTO> FamilyCharUpdateDTO { get; set; }
        [NotMapped]
        public DbSet<UserPermissionDTO> UserPermissionDTO { get; set; }
        [NotMapped]
        public DbSet<UserPermissionUpdateDTO> UserPermissionUpdateDTO { get; set; }
        [NotMapped]
        public DbSet<FilterUserPermissionDTO> FilterUserPermissionDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyTreeDTO> FamilyTreeDTO { get; set; }
        [NotMapped]
        public DbSet<NewsListDTO> NewsListDTO { get; set; }
        [NotMapped]
        public DbSet<UserToReturnDTO> UserToReturnDTO { get; set; }
        [NotMapped]
        public DbSet<UserRelationDTO> UserRelationDTO { get; set; }
        [NotMapped]
        public DbSet<WifeDTO> WifeDTO { get; set; }
        [NotMapped]
        public DbSet<BlogsDetailsDTO> BlogsDetailsDTO { get; set; }
        [NotMapped]
        public DbSet<MyBlogDTO> MyBlogDTO { get; set; }
        [NotMapped]
        public DbSet<BlogDetailsDTO> BlogDetailsDTO { get; set; }
        [NotMapped]
        public DbSet<UserReturnDTO> UserReturnDTO { get; set; }
        [NotMapped]
        public DbSet<ReturnDTO> TestDTO { get; set; }
        [NotMapped]
        public DbSet<BlogMDTO> BlogMDTO { get; set; }
        [NotMapped]
        public DbSet<NewsEditDTO> NewsEditDTO { get; set; }
        [NotMapped]
        public DbSet<NewsImagesEditDTO> NewsImagesEditDTO { get; set; }
        [NotMapped]
        public DbSet<UserProfileDTO> UserProfileDTO { get; set; }
        [NotMapped]
        public DbSet<ImagesDTO> ImagesDTO { get; set; }
        [NotMapped]
        public DbSet<FamilyCharactersSearchDTO> FamilyCharactersSearchDTO { get; set; }
        [NotMapped]
        public DbSet<UserInfoDTO> UserInfoDTO { get; set; }
        [NotMapped]
        public DbSet<UpdateUserLoginDataDTO> UpdateUserLoginDataDTO { get; set; }
        [NotMapped]
        public DbSet<AddBlogDTO> AddBlogDTO { get; set; }
        [NotMapped]
        public DbSet<NewsAddedDTO> NewsAddedDTO { get; set; }
        [NotMapped]
        public DbSet<UserProfileDataDTO> UserProfileDataDTO { get; set; }
        [NotMapped]
        public DbSet<UserNotificationsDTO> UserNotificationsDTO { get; set; }
        [NotMapped]
        public DbSet<NewsDetailsAdminDTO> NewsDetailsAdminDTO { get; set; }
        [NotMapped]
        public DbSet<UserParentsDTO> UserParentsDTO { get; set; }
        
        #endregion

        #region dbset models 
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserClaim> UserClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogComment> BlogComment { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<DefinitionLineage> DefinitionLineage { get; set; }
        public DbSet<FamilyCharacters> FamilyCharacters { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<NewsImage> NewsImage { get; set; }
        public DbSet<NewsType> NewsType { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }
        //public DbSet<NotificationType> NotificationType { get; set; }
        //public DbSet<UserNotification> UserNotification { get; set; }
        public DbSet<Terms> Terms { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<UserStatus> Status { get; set; }
        public DbSet<Wife> Wife { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<RequestStatus> RequestStatus { get; set; }

        #endregion

    }
}
