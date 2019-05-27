using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class RecordUserLocationService : IRecordUserLocationService
    {
        public async Task<Response<bool>> Record(UserLocation userLocation)
        {
            return Response<bool>.Wrap(() =>
            {
                var repo = RepoCache.Get<User>();
                var user = repo.GetQuery().FirstOrDefault(x => x.ID == userLocation.UserID);
                user.Lat = userLocation.Lat;
                user.Lon = userLocation.Lon;
                repo
                //.RemoveRange(x => x.ID == user.ID)
                //.Add(user)
                .Save();
                return true;
            });
        }
    }
}
