using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public string NotifyName { get; set; }
        public int NewsId { get; set; }
        public string NotifyType { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime AddDateM { get; set; }
        public DateTime AddDateH { get; set; }
        public bool IsDelete { get; set; } = false;
        public int UserId { get; set; }
    }
}
