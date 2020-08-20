using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsDetailsAdminDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public string ByUser { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool AllowAddNews { get; set; }
        public bool AllowComment { get; set; }
        public int CommentCount { get; set; }
        public bool? IsAccepted { get; set; }
        public string NewsType { get; set; }
    }
}
