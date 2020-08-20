using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class FiltersDTO
    {
        public string SearchBy { get; set; }
        public string SearckKey { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        //public int Page { get; set; } = 1;
        //public int MyProperty { get; set; } = 20;
    }
}
