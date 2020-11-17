using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
//using DatingAppCore.Repo.EF.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetProfileService : ISetProfileService
    {
        public async Task<Response<bool>> Set(SetPropertiesRequest request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<UserProfileField>().SetProfile(request));
        }
    }
}