using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class NewsType
    {
        public int Id { get; set; }
        public string NewsType1 { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
