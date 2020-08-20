using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserCompleteRegisterDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDateM { get; set; }
        public DateTime BirthDateH { get; set; }
    }
}
