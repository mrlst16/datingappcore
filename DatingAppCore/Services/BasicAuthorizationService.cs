using System;
using System.Linq;
using System.Text;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.API.Services.Interfaces;
using DatingAppCore.API.Services.Requests;
using DatingAppCore.Repo.Clients;

namespace DatingAppCore.API.Services
{
    public class BasicAuthorizationService : IAuthorizationService
    {

        public Response<bool> Authorize(AuthorizationRequest request)
        {
            try
            {
                var str = request.Data
                    .Replace("basic", "")
                    .Trim();

                string decoded = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(str));

                string username = decoded.Split(':').First();
                string password = decoded.Split(':').Last();

                ClientAuth auth = RepoCache
                    .Get<ClientAuth>()
                    .GetQuery()
                    .FirstOrDefault(x => x.ClientID == request.ClientID);

                return auth.UserName == username && auth.Password == password;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}