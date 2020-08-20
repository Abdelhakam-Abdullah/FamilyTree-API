using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class UserType
    {
        public int Id { get; set; }
        public string UType { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
