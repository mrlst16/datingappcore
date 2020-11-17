using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISearchUsersService
    {
        Task<Response<IEnumerable<User>>> Search(SearchUserRequest request);
    }
}