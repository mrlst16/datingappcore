using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetPropertiesService : ISetPropertiesService
    {
        public Response<bool> Set(SetPropertiesRequest request)
        {
            return Response<bool>.Wrap(() =>
            {
                RepoCache
                    .Get<UserProfileField>()
                    .AddRange(request.Profile.Select(x => new UserProfileField()
                    {
                        UserID = request.UserID,
                        IsSetting = false,
                        Name = x.Key,
                        Value = x.Value
                    }), true)
                    .AddRange(request.Settings.Select(x => new UserProfileField()
                    {
                        UserID = request.UserID,
                        IsSetting = true,
                        Name = x.Key,
                        Value = x.Value
                    }), true);
                return true;
            });
        }
    }
}