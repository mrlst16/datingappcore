using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface IRecordUserLocationService
    {
        Task<Response<bool>> Record(UserLocationDTO userLocation);
    }
}