using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class BlodCommentsDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string ByUser { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
    }
}
