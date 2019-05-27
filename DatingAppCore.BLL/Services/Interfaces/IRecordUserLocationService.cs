using CommonCore.Responses;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IRecordUserLocationService
    {
        Task<Response<bool>> Record(UserLocation userLocation);
    }
}