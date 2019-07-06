using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface ISearchUsersService
    {
        Task<Response<IEnumerable<UserDTO>>> Search(SearchUserRequest request);
    }
}