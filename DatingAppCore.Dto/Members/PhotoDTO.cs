using CommonCore.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Members
{
    public class PhotoDTO : DtoBase
    {
        public Guid UserID { get; set; }
        public int Rank { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public AccessLevelEnum Access { get; set; } = AccessLevelEnum.Public;
    }
}