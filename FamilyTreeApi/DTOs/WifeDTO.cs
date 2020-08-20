using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class WifeDTO
    {
        public int Id { get; set; }
        public string wName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
