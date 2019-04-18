using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.DTO.Members;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IPotentialMatchesService
    {
        Response<IEnumerable<UserDTO>> FindPotentialMatches(FindMatchRequest request);
    }
}
