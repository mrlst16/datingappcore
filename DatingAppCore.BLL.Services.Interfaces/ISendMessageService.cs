using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Messages;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISendMessageService
    {
        Task<Response<bool>> Send(MessageDTO request);
    }
}
