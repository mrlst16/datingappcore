using CommonCore.Interfaces.Repository;
using DatingAppCore.BLL.Interfaces.Loaders.Locations;
using DatingAppCore.BLL.Interfaces.Services;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Matching;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Loaders
{
    public class MatchesLoader : IMatchesService
    {
        private readonly ILocationsLoader _locationsLoader;
        private readonly IEntityRepository<User> _usersRepository;
        private readonly IEntityRepository<Match> _matchRepository;

        public MatchesLoader(
            ILocationsLoader locationsLoader,
            IEntityRepository<User> usersRepository,
            IEntityRepository<Match> matchRepository
            )
        {
            _locationsLoader = locationsLoader;
            _usersRepository = usersRepository;
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request)
        {
            request.AlreadyMatched = (await _matchRepository.Read(x => x.Swiper == request.UserID)).Select(x => x.Swipee);
            List<User> result = new List<User>();

            while (result.Count() < request.Take && await Chunk(request, result)){
                result.AddRange(result);
            }

            return result;
        }

        private async Task<bool> Chunk(FindMatchesRequest request, List<User> result)
        {
            var user = await _usersRepository.Read(request.UserID);
            var usersWithinLocation = await _locationsLoader.UsersWithinLocation(request);

            var tasks = new List<Task<User>>();

            while (result.Count() < request.Take && usersWithinLocation.Any())
            {
                var userWithinLocation = usersWithinLocation.First();
                var task = MatchExcludingLocation(user, userWithinLocation.ID);
                tasks.Add(task);
            }

            while(tasks.Any())
            {
                var task = await Task.WhenAny<User>(tasks);
                var match = await task;
                if (match != null)
                    result.Add(match);
            }    

            return result.Any();
        }

        private async Task<User> MatchExcludingLocation(User searchingUser, Guid potentialMatchUserId)
        {
            var potentialMatchUser = await _usersRepository.Read(potentialMatchUserId);
            
            foreach(var searchParam in potentialMatchUser.SearchParameters)
            {
                var userParam = searchingUser.SearchParameters.FirstOrDefault(x => x.Key == searchParam.Key);
                if (userParam == null || !userParam.Match(searchParam))
                    return null;
            }
            return potentialMatchUser;
        }
    }
}
