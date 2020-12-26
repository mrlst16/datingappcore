using CommonCore.Interfaces.Repository;
using CommonCore2.RuleTrees;
using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.BLL.Interfaces.Loaders.Locations;
using DatingAppCore.BLL.Interfaces.Services;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Matching;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Loaders
{
    public class MatchesLoader : IMatchesLoader
    {
        private readonly ILocationsLoader _locationsLoader;
        private readonly ICrudRepository<User> _usersRepository;
        private readonly ICrudRepository<Match> _matchRepository;
        private readonly ICrudRepository<Swipe> _swipesRepository;

        public MatchesLoader(
            ILocationsLoader locationsLoader,
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _locationsLoader = locationsLoader;
        }

        public async Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request)
        {
            request.AlreadySwiped = (await _matchRepository.Read(x => x.Swiper == request.UserID)).Select(x => x.Swipee);
            List<User> result = new List<User>();

            while (result.Count() < request.Take && await FindPtentialMatches(request, result))
            {
                result.AddRange(result);
            }

            return result;
        }

        public async Task Swipe(Swipe swipe)
        {
            var existingSwipe = await _swipesRepository.Read(x=> x.UserFromID == swipe.UserFromID);
            if (existingSwipe != null) return;
            await _swipesRepository.Create(swipe);
        }

        private async Task<bool> FindPtentialMatches(FindMatchesRequest request, List<User> result)
        {
            var users = await _usersRepository.Read(x=> x.ID == request.UserID);
            var user = users.FirstOrDefault();
            var usersWithinLocation = await _locationsLoader.UsersWithinLocation(request);

            var tasks = new Queue<Task<User>>();

            while (result.Count() < request.Take && usersWithinLocation.Any())
            {
                var userWithinLocation = usersWithinLocation.First();
                var task = MatchExcludingLocation(user, userWithinLocation.ID);
                tasks.Enqueue(task);
            }

            while (tasks.TryDequeue(out Task<User> task))
            {
                var match = await task;
                if (match != null)
                    result.Add(match);
            }

            return result.Any();
        }

        private async Task<User> MatchExcludingLocation(User searchingUser, Guid potentialMatchUserId)
        {
            var potentialMatchUsers = await _usersRepository.Read(x=> x.ID == potentialMatchUserId);
            var potentialMatchUser = potentialMatchUsers.FirstOrDefault();
            DictionaryValueProvider dictionaryValueProvider = new DictionaryValueProvider(potentialMatchUser.Profile);
            RuleTreeAssembler ruleTreeAssembler = new RuleTreeAssembler(dictionaryValueProvider);
            await ruleTreeAssembler.Assemble(searchingUser.SearchParameters);
            var result = await searchingUser.SearchParameters.Passes();
            return result ? potentialMatchUser : null;
        }
    }
}
