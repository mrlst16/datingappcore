using CommonCore.Repo.Repository;
using CommonCore.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Repo.Messaging;
using System.Linq;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.Dto.Messages;

namespace DatingAppCore.BLL.Services
{
    public class GetConversationService : IGetConversationService
    {
        public async Task<Response<ConversationDTO>> ReadMessages(GetConversationRequest request)
        {
            return Response<ConversationDTO>.Wrap(() =>
            {
                var conversation = RepoCache.Get<Conversation>()
                    .GetConversation(request)
                    .ToDto();
                return conversation;
            });
        }
    }
}
