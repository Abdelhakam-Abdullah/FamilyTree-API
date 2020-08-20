using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public bool IsDelete { get; set; }
    }
}
