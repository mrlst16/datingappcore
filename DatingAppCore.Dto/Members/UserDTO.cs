using CommonCore.DTO;
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
        [Required]
        public string UserName { get; set; }
        public string ExternalID { get; set; }
        public IDTypeEnum IdType { get; set; }

        public Dictionary<string, string> Profile { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();

        public List<PhotoDTO> Photos { get; set; }
    }
}
