using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface IReadMessageService
    {
        Task<Response<IEnumerable<MessageDTO>>> ReadMessages(LookupByUserIDRequest request);
    }
}
