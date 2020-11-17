using System;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Entities.Messaging;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISendMessageService
    {
        Task<Response<bool>> Send(Message request);
    }
}
