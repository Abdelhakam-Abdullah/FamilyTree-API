using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class FamilyCharacterDetailsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
