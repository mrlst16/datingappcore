using CommonCore.Responses;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Repo.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IReadMessageService
    {
        Task<Response<IEnumerable<Message>>> ReadMessages(LookupByUserIDRequest request);
    }
}
