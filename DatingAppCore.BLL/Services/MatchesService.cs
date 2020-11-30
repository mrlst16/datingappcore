using DatingAppCore.BLL.Interfaces.Services;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class MatchesService : IMatchesService
    {



        public async Task<IEnumerable<User>> FindPotentialMatches(User user)
        {
            IEnumerable<User> results = new List<User>();


            return results;
        }

        public Task<IEnumerable<User>> FindPotentialMatches(FindMatchesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
