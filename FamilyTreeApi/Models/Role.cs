using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class Role : IdentityRole<int>
    {
        public string NameAr { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
