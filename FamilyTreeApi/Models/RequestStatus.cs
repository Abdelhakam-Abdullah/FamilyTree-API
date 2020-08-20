using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string ReqStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
