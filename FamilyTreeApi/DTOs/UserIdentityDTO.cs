using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserIdentityDTO
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool AcceptedAdd { get; set; }
    }
}
