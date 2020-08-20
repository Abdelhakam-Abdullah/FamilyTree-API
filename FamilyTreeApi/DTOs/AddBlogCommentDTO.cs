using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddBlogCommentDTO
    {
        public string Comment { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool IsDelete { get; set; } = false;
        public bool? IsAccepted { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
    }
}
