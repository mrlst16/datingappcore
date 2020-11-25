using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISetSettingsService
    {
        Task<Response<bool>> Set(SetPropertiesRequest request);
    }
}