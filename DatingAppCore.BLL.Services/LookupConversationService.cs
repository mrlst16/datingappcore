using CommonCore.Repo.Repository;
using CommonCore.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Dto.Requests;
//using DatingAppCore.Repo.EF.Messaging;
using System.Linq;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.Dto.Messages;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.BLL.Services
{
    public class LookupConversationService : ILookupConversationService
    {
        public async Task<Response<ConversationDTO>> Lookup(GetConversationRequest request)
        {
            return null;
            //return Response<ConversationDTO>.Wrap(() =>
            //{
            //    var conversation = RepoCache.Get<Conversation>()
            //        .GetConversation(request)
            //        .ToDto();
            //    return conversation;
            //});
        }
    }
}
