using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddChilredDTO
    {
        [Required]
        public int ParentId { get; set; }
        [Required]
        public int FamilyId { get; set; }
        public string IdentityNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        [Required]
        public DateTime BirthDateM { get; set; }
        public DateTime BirthDateH{ get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string FaceBookAcc { get; set; }
        public string TwitterAcc { get; set; }
        [Required]
        public int MotherId { get; set; }
        public int UserTypeId { get; set; }
        public bool AcceptedAdd { get; set; } = false;
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public string Image { get; set; }

        public bool? IsLouck { get; set; }
    }
}
