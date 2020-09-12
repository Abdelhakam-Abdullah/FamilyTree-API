using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddUserToRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
