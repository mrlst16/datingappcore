using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetMatchesService
    {
        Task<Response<IEnumerable<User>>> GetMatches(LookupByUserIDRequest request);

        Task<Response<bool>> IsMatch(Guid user1id, Guid user2id);
    }
}