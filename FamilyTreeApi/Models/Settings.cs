using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string MailAddress { get; set; }
        public string CPanelLogo { get; set; }
        public string LoginLogo { get; set; }
        public string AppLogo { get; set; }

        public int MailServerPort { get; set; }
        public string MailUserName { get; set; }
        public string MailPassword { get; set; }
        public string MailServer { get; set; }
        

    }
}
