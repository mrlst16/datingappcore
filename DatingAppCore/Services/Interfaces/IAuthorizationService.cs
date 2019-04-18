using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DatingAppCore.API.Services.Requests;

namespace DatingAppCore.API.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Response<bool> Authorize(AuthorizationRequest request);
    }
}
