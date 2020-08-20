using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserReturnDTO
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string FaceBookAcc { get; set; }
        public string TwitterAcc { get; set; }
        public bool AcceptedAdd { get; set; }
        public int? ParentId { get; set; }
    }
}
