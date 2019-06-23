using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Reviewing
{
    public class ReviewBadgeTemplateDTO : DtoBase
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }
    }
}
