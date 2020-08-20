using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? FamilyId { get; set; }
        public string IdentityNumber { get; set; }
        public string UserName { get; set; }
        //public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public DateTime? CreatedDateM { get; set; }
        //public DateTime? CreatedDateH { get; set; }
        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string FaceBookAcc { get; set; }
        public string TwitterAcc { get; set; }
        public int? MotherId { get; set; }
        //public int UserTypeId { get; set; }
        //public bool AcceptedAdd { get; set; } = false;
        public int? GenderId { get; set; }
        public int? StatusId { get; set; }
        public string Image { get; set; }

        public bool? AllowAddChildren { get; set; }
        public bool? AllowAddFamilyChar { get; set; }
        public bool? AllowNews { get; set; }
        public bool? AllowBlog { get; set; }
    }
}
