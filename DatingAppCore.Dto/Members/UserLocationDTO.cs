using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Members
{
    public class UserLocationDTO : DtoBase
    {
        public Guid UserID { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}