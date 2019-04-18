using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO.Members
{
    public class PhotoDTO : DtoBase
    {
        public Guid UserID { get; set; }
        public int Rank { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public AccessLevel Access { get; set; } = AccessLevel.Public;
    }
}
