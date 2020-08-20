using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddBlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool AllowComment { get; set; } = false;
        public int UserId { get; set; }
        public bool? IsAccepted { get; set; }

        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
    }
}
