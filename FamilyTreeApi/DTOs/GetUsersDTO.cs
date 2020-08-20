using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class GetUsersDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? AddDateM { get; set; }
        public DateTime? BirthDateM { get; set; }
    }
}
