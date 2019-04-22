using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Response<bool> Authorize(IHeaderDictionary headers);
    }
}
