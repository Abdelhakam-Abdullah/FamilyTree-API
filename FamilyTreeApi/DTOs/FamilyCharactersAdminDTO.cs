using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class FamilyCharactersAdminDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CharName { get; set; }
        public string Image { get; set; }
        public DateTime? BirthDateM { get; set; }
        public DateTime? BirthDateH { get; set; }
        public string Description { get; set; }
        public bool? IsAccepted { get; set; }
        public string AddedBy { get; set; }
        public DateTime? CreatedDateM { get; set; }
        public DateTime? CreatedDateH { get; set; }
        

    }
}
