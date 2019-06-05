using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetMatchesService
    {
        Task<Response<IEnumerable<UserDTO>>> GetMatches(Guid userid);

        Task<Response<bool>> IsMatch(Guid user1id, Guid user2id);
    }
}