using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class NewsImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool IsMain { get; set; }
        public bool IsDelete { get; set; }

        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
