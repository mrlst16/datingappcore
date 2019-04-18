using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.DTO.Matching;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISwipeService
    {
        Response<bool> Swipe(SwipeDTO request);
    }
}
