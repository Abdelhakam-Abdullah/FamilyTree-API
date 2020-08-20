using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserPermissionUpdateDTO
    {
        public int Id { get; set; }
        public bool IsAddChild { get; set; }
        public bool IsAddFamilyChar { get; set; }
        public bool IsAddBlogs { get; set; }
        public bool IsAddNews { get; set; }
    }
}
