using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class SettingsDTO
    {
        public int Id { get; set; }
        public string CPanelLogo { get; set; }
        public string LoginLogo { get; set; }
        public string AppLogo { get; set; }
    }
}
