using System;
using CommonCore.Repo.Entities;
using DatingAppCore.Entities.Enum;

namespace DatingAppCore.Entities.Members
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public Guid ClientID { get; set; }
        public string ExternalID { get; set; }
        public IDTypeEnum IdType { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime? Birthday { get; set; }

    }
}
