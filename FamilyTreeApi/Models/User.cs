using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public class User : IdentityUser<int>
    {
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        //public string Gender { get; set; }
        public string Image { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string FaceBookAcc { get; set; }
        public string TwitterAcc { get; set; }
        public bool IsDelete { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int? MotherId { get; set; }

        public bool AllowAddChildren { get; set; }
        public bool AllowAddFamilyChar { get; set; }
        public bool AllowNews { get; set; }
        public bool AllowBlog { get; set; }
        public bool AcceptedAdd { get; set; }

        public int? ParentId { get; set; }
        public virtual User Parent { get; set; }
        public virtual HashSet<User> UserChild { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public int? StatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public int FamilyId { get; set; }
        //public virtual Family Family { get; set; }

        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public virtual ICollection<UserNotification> UserNotification { get; set; }
        public virtual ICollection<Blog> Blog { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<BlogComment> BlogComment { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual FamilyCharacters FamilyCharactersUser { get; set; }

        public bool Allow_GeneralNews { get; set; }
        public bool Allow_Monasabat { get; set; }
        public bool Allow_Mawaled { get; set; }
        public bool Allow_Wafeaat { get; set; }

        public bool? IsLouck { get; set; } = false;
    }
}
