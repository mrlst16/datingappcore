using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.Dto.Reviewing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.EF.Reviewing;

namespace DatingAppCore.BLL.Services
{
    public class GetClientReviewBadgesService : IGetClientReviewBadgesService
    {
        private readonly IGetUserService _getUserService;

        public GetClientReviewBadgesService(
            IGetUserService getUserService
            )
        {
            _getUserService = getUserService;
        }

        public async Task<Response<IEnumerable<ReviewBadgeTemplateDTO>>> GetClientReviewBadges(Guid clientID)
        {
            return null;
            //return Response<IEnumerable<ReviewBadgeTemplateDTO>>.Wrap(() =>
            //{
            //    return RepoCache.Get<ReviewBadgeTemplate>()
            //        .GetQuery()
            //        .Where(x => x.ClientID == clientID)
            //        .Select(x => x.ToDto());
            //});
        }
    }
}
