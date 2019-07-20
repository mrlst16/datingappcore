using CommonCore.DTO;
using System;
using System.Collections.Generic;

namespace DatingAppCore.Dto.Messages
{
    public class ConversationDTO : DtoBase
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
        public string ConnectionID { get; set; }

        public List<MessageDTO> Messages { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ConversationDTO dto)
            {
                return
                    (User1ID == dto.User1ID && User2ID == dto.User2ID)
                    || (User1ID == dto.User2ID && User2ID == dto.User1ID);
            }
            else return false;
        }
    }
}