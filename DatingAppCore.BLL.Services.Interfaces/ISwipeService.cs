using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Matching;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISwipeService
    {
        Task<Response<bool>> Swipe(SwipeDTO request);
    }
}
