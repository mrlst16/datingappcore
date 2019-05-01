using CommonCore.DTO;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Matching;
using DatingAppCore.DTO.Messages;
using DatingAppCore.DTO.Reviewing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO.Members
{
    public class UserDTO : DtoBase
    {
        public string UserName { get; set; }
        public string ExternalID { get; set; }
        public IDTypeEnum IdType { get; set; }

        public Dictionary<string, string> Profile { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();

        public List<PhotoDTO> Photos { get; set; }

        public ICollection<MessageDTO> Inbox { get; set; }
        public ICollection<MessageDTO> Sent { get; set; }

        public ICollection<SwipeDTO> SwipesSent { get; set; }
        public ICollection<SwipeDTO> SwipesReceived { get; set; }

        public ICollection<ReviewDTO> ReviewsSent { get; set; }
        public ICollection<ReviewDTO> ReviewReceived { get; set; }

        public ICollection<GrantedPermissionsDTO> AsGrantee { get; set; }
        public ICollection<GrantedPermissionsDTO> AsGrantor { get; set; }
    }
}
