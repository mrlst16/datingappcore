using CommonCore.Responses;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface IGetConversationService
    {
        Task<Response<ConversationDTO>> ReadMessages(GetConversationRequest request);
    }
}
