using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsOperDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NewsTypeId { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public bool AllowComment { get; set; }
        public bool? IsAccepted { get; set; }
        public int UserId { get; set; }

        public List<NewsImageDTO> NewsImages { get; set; }
    }
}
