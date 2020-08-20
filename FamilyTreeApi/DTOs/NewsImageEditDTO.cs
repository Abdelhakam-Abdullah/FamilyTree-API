using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsImageEditDTO
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int NewsId { get; set; }
        public bool IsMain { get; set; }
    }
}
