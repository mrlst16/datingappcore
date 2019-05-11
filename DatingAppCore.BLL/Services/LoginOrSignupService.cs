using System;
using System.Linq;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.BLL.Signup.Requests;
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
                }
                else
                {
                    repo.Add(request.User?.ToEntity());
                    response.User = request.User;
                }
                repo.Save();
                return response;
            });
        }
    }
}