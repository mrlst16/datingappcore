using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Services
{
    public class BasicAuthorizationService: IAuthorizationService
    {
        public ApiResponse<bool> Authorize(IHeaderDictionary headers)
        {

            var str = headers?["Authorization"].FirstOrDefault()?
                .Split(' ')
                .Last()
                .Trim();

            var clientid = Guid.Parse(headers?["ClientID"].First());

            string decoded = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(str));

            string username = decoded.Split(':').First();
            string password = decoded.Split(':').Last();

            return null;
        }

        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
        {
            throw new NotImplementedException();
        }
    }
}