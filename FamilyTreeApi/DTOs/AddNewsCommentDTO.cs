using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class AddNewsCommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool? IsAccepted { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
    }
}
