using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class ForgotPasswordDTO
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }
}
