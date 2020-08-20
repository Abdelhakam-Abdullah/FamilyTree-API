using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class FamilyTreeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ParenName { get; set; }
        public int? ParentId { get; set; }

    }
}
