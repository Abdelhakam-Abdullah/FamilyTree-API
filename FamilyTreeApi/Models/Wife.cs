using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class Wife
    {
        public int Id { get; set; }
        public string WName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
