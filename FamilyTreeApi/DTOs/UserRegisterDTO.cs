using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserRegisterDTO
    {
        public int? ParentId { get; set; }

        [Required]
        public int FamilyId { get; set; }

        public string IdentityNumber { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        //====================================
        [Required]
        public DateTime CreatedDateM { get; set; }

        [Required]
        public DateTime CreatedDateH { get; set; }

        public bool AcceptedAdd { get; set; } = false;
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? GenderId { get; set; }
        public int? StatusId { get; set; }

        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
    }
}
