using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Members
{
    public class GrantedPermissionsDTO : DtoBase
    {
        public Guid GrantorID { get; set; }
        public Guid GranteeID { get; set; }
        public int Permissions { get; set; }
    }
}