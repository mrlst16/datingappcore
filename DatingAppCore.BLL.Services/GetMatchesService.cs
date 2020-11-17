using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;
//using DatingAppCore.Repo.EF.Matching;
//using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class GetMatchesService : IGetMatchesService
    {
        public async Task<Response<IEnumerable<UserDTO>>> GetMatches(LookupByUserIDRequest userid)
        {
            return Response<IEnumerable<UserDTO>>.Wrap(() => RepoCache.Get<Swipe>().GetMatches(userid));
        }
        
        public async Task<Response<bool>> IsMatch(Guid user1id, Guid user2id)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Swipe>().IsMatch(user1id, user2id));
        }
    }
}
