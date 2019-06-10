using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.DTO.Members;

namespace DatingAppCore.Interfaces
{
    public interface IGetUserService
    {
        Task<Response<UserDTO>> GetUser(GetUserRequest request);
    }
}