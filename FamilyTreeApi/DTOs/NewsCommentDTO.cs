using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsCommentDTO
    {
        public int Id { get; set; }
        public string ByUser { get; set; }
        public string Comment { get; set; }
        public string UserImage { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
    }
}
