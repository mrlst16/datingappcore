using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Members;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Services
{
    public class GetUserService : IGetUserService
    {
        public async Task<Response<UserDTO>> GetUser(GetUserRequest request)
        {
            return Response<UserDTO>.Wrap(() => RepoCache.Get<User>().GetUser(request));
        }
    }
}