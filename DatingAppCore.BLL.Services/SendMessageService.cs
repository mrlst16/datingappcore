using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Messages;
//using DatingAppCore.Repo.EF.Messaging;

namespace DatingAppCore.BLL.Services
{
    public class SendMessageService : ISendMessageService
    {
        public async Task<Response<bool>> Send(MessageDTO request)
        {
            return null;
            //return Response<bool>.Wrap(() => RepoCache.Get<Message>().SendMessage(request));
        }


        private bool SendMessage(Repository<Message> repository, MessageDTO request)
        {
            return false;
            //Conversation conversation = RepoCache.Get<Conversation>()
            //    .RegisterOrLogin(request.From, request.To);

            //var entity = request.ToEntity();
            //entity.ConversationID = conversation.ID;
            //repository
            //        .Add(entity)
            //        .Save();
            //return true;
        }

    }
}
