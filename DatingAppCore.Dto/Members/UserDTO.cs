using CommonCore.DTO;
using DatingAppCore.Dto.Matching;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Dto.Reviewing;
using System;
using System.Collections.Generic;

namespace DatingAppCore.Dto.Members
{
    public class UserDTO : DtoBase
    {
        public string UserName { get; set; }
        public string ExternalID { get; set; }
        public IDTypeEnum IdType { get; set; }
        public Guid ClientID { get; set; }
        public DateTime? Birthday { get; set; }

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
