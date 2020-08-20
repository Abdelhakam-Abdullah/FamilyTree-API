using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserNotificationsDTO
    {
        public int Id { get; set; }
        public string NotifyName { get; set; }
        public string NotifyType { get; set; }
        public DateTime AddDateM { get; set; }
        public DateTime AddDateH { get; set; }
        public bool IsRead { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
    }
}
