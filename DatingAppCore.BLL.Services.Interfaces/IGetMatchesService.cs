using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetMatchesService
    {
        Task<Response<IEnumerable<UserDTO>>> GetMatches(LookupByUserIDRequest request);

        Task<Response<bool>> IsMatch(Guid user1id, Guid user2id);
    }
}