using CommonCore.Repo.Entities;
using System;
namespace DatingAppCore.Entities.Reviewing
{
    public class Review : EntityBase
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public double Rating { get; set; }
    }
}
