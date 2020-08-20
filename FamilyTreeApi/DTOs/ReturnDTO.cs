using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class ReturnDTO
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string NotifyName { get; set; }
        public string NotifyType { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
    }
}
