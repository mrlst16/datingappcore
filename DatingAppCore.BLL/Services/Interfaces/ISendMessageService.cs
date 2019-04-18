using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.DTO.Messages;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISendMessageService
    {
        Response<bool> Send(MessageDTO request);
    }
}
