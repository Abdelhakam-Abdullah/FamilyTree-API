using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool? IsAccepted { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public int? NewsId { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
