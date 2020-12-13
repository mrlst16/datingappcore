using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.BLL.Interfaces.Services;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Matching;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IMatchesLoader _matchesLoader;

        public MatchesService(
            IMatchesLoader matchesLoader
            )
        {
            _matchesLoader = matchesLoader;
        }

        public async Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request)
            => await _matchesLoader.FindPotentialMatches(request);

        public async Task Swipe(Swipe swipe)
            => await _matchesLoader.Swipe(swipe);
    }
}
