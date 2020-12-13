using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Matching;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Interfaces.Services
{
    public interface IMatchesService
    {
        Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request);
        Task Swipe(Swipe swipe);
    }
}
