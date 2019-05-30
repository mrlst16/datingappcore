using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IMatchesService
    {
        Task<Response<IEnumerable<UserDTO>>> GetMatches(Guid userid);
    }
}