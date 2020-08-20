using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UpdateUserLoginDataDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
