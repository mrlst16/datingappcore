using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Members;

namespace DatingAppCore.BLL.Services
{
    public class GetUserService : IGetUserService
    {
        public async Task<Response<UserDTO>> GetUser(GetUserRequest request) => Response<UserDTO>.Wrap(() => UsersRepoHelper.GetUser(request));
    }
}
