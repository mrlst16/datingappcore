using CommonCore.Responses;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ILookupConversationService
    {
        Task<Response<ConversationDTO>> Lookup(GetConversationRequest request);
    }
}
