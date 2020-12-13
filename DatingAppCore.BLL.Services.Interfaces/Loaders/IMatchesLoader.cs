using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Matching;
using DatingAppCore.Entities.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Interfaces.Loaders
{
    public interface IMatchesLoader
    {
        Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request);
        Task Swipe(Swipe swipe);
    }
}
