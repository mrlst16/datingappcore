using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Repo.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Helpers.RepoHelpers;

namespace DatingAppCore.BLL.Services
{
    public class ReadMessagesService : IReadMessageService
    {
        public async Task<Response<IEnumerable<Message>>> ReadMessages(LookupByUserIDRequest request)
        {
            return Response<IEnumerable<Message>>.Wrap(() => RepoCache.Get<Message>().GetMessagesByUserID(request));
        }
    }
}
