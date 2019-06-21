using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;

namespace DatingAppCore.Interfaces
{
    public interface IPotentialMatchesService
    {
        Task<Response<IEnumerable<UserDTO>>> FindPotentialMatches(FindMatchRequest request);
    }
}
