using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class FamilyCharacters
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool? IsAccepted { get; set; }
        public bool IsDelete { get; set; }

        public int? CharId { get; set; }
        public virtual User UserChar { get; set; }

        public int? UserId { get; set; }
    }
}
