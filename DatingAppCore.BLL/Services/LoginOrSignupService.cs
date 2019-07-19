using System;
using System.Linq;
using System.Threading.Tasks;
using CommonCore.Repo;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.BLL.Services
{
    public class LoginOrSignupService : ILoginOrSignupService
    {
        public async Task<Response<LoginOrSignupResponse>> LoginOrSignup(LoginOrSignupRequest request)
        {
            return Response<LoginOrSignupResponse>.Wrap(() =>
            {
                var validated = request.User.Validate();
                if (!validated) return null;
                var response = new LoginOrSignupResponse();
                var repo = RepoCache.Get<User>();
                var user = repo.GetQuery().FirstOrDefault(x =>
                 x.ExternalID == request.User.ExternalID
                     && x.IdType == request.User.IdType);

                response.Existed = (user != null);
                if (response.Existed)
                {
                    response.User = user.ToDto();
                    user.ClientID = request.User.ClientID;
                    user.UserName = request.User.UserName;
                    user.LastUpdated = DateTime.UtcNow;
                    user.Birthday = request.User.Birthday;
                    repo.Set().Update(user);
                }
                else
                {
                    var resultUser = request.User?
                        .ToEntity()
                        .EnsureID();
                    repo.Add(resultUser);
                    response.User = resultUser.ToDto();
                }
                repo.Save();
                return response;
            });
        }
    }
}