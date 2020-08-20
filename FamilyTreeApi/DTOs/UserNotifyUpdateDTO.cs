using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserNotifyUpdateDTO
    {
        public int UserId { get; set; }
        public bool Allow_GeneralNews { get; set; }
        public bool Allow_Monasabat { get; set; }
        public bool Allow_Mawaled { get; set; }
        public bool Allow_Wafeaat { get; set; }
    }
}
