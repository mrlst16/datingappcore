using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IPotentialMatchesService
    {
        Task<Response<IEnumerable<User>>> FindPotentialMatches(FindMatchRequest request);
    }
}
