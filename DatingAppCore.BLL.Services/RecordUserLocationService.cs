using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Members;
//using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class RecordUserLocationService : IRecordUserLocationService
    {
        public async Task<Response<bool>> Record(UserLocationDTO userLocation)
        {
            return null;
            //return Response<bool>.Wrap(() => RepoCache.Get<User>().UpdateUserLocation(userLocation.ToEntity()));
        }
    }
}