using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class TreeAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNum { get; set; }
        public string UserImage { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        //public int? Parent_Id { get; set; }
        public List<TreeAdminDTO> Children { get; set; }
    }
}
