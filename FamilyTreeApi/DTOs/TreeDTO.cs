using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class TreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserImage { get; set; }
        public List<TreeDTO> Children { get; set; }
    }
}
