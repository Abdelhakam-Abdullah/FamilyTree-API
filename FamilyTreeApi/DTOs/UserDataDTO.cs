using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class UserDataDTO
    {
        public UserToReturnDTO UserData { get; set; }

        public UserRelationDTO Parent { get; set; }
        public UserRelationDTO GrandParent { get; set; }
        public List<UserRelationDTO> Children { get; set; }
        public List<UserRelationDTO> Brothers { get; set; }
        public List<UserRelationDTO> Uncles { get; set; }
        public List<WifeDTO> Wifes { get; set; }
    }
}
