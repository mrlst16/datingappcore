using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetUserService
    {
        Task<Response<User>> GetUser(GetUserRequest request);
    }
}