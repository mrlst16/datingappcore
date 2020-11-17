using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Comparers;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
//////using DatingAppCore.Repo.EF.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetPropertiesService : ISetProfileService
    {
        public async Task<Response<bool>> Set(SetPropertiesRequest request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<UserProfileField>().SetPoperties(request));
        }
    }
}