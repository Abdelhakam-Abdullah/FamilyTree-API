using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddNewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NewsPlace { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public int NewsTypeId { get; set; }
        public bool IsAccepted { get; set; }
        public bool AllowComment { get; set; }
        public int UserId { get; set; }
    }
}
