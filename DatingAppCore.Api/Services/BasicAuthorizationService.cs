using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using CommonCore.Services.Interfaces;
using DatingAppCore.Repo.Clients;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Services
{
    public class BasicAuthorizationService : IAuthorizationService
    {
        public Response<bool> Authorize(IHeaderDictionary headers)
        {
            var response = new Response<bool>();

            try
            {

                var str = headers?["Authorization"].FirstOrDefault()?
                    .Split(' ')
                    .Last()
                    .Trim();

                var clientid = Guid.Parse(headers?["ClientID"].First());

                string decoded = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(str));

                string username = decoded.Split(':').First();
                string password = decoded.Split(':').Last();

                ClientAuth auth = RepoCache
                    .Get<ClientAuth>()
                    .GetQuery()
                    .FirstOrDefault(x => x.ClientID == clientid);

                response.Result = auth.UserName == username && auth.Password == password;
            }
            catch (Exception e)
            {
                response += e;
            }

            return response;
        }
    }
}