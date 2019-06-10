using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;

namespace DatingAppCore.Interfaces
{
    public interface ISetProfileService
    {
        Task<Response<bool>> Set(SetPropertiesRequest request);
    }
}
