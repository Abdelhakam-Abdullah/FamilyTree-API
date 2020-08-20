using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string Symbole { get; set; }
        public bool IsDelete { get; set; }

        //public virtual ICollection<User> User { get; set; }
    }
}
