using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserParentsDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
