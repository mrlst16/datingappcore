using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Messages
{
    public class ConversationDTO
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }

        public List<MessageDTO> Messages { get; set; }
    }
}
