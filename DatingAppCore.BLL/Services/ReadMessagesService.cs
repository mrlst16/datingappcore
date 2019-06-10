using CommonCore.Repo.Repository;
using CommonCore.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.DTO.Messages;
using DatingAppCore.Repo.Messaging;
using System.Linq;
using DatingAppCore.BLL.Adapters;

namespace DatingAppCore.BLL.Services
{
    public class ReadMessagesService : IReadMessageService
    {
        public async Task<Response<IEnumerable<MessageDTO>>> ReadMessages(LookupByUserIDRequest request)
        {
            return Response<IEnumerable<MessageDTO>>.Wrap(() =>
            {
                return RepoCache.Get<Message>().GetMessagesByUserID(request).Select(x => x.ToDto());
            });
        }
    }
}
