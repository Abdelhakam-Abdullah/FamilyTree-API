using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool? IsAccepted { get; set; }
        public bool IsDelete { get; set; }
        public bool AllowComment { get; set; }
        public int? UserId { get; set; }
        
        public virtual User User { get; set; }        
        public virtual ICollection<BlogComment> BlogComment { get; set; }
    }
}
