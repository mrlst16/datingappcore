using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Dto.Reviewing;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Reviewing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Adapters;

namespace DatingAppCore.BLL.Services
{
    public class GetClientReviewBadgesService : IGetClientReviewBadgesService
    {
        public async Task<Response<IEnumerable<ReviewBadgeTemplateDTO>>> GetClientReviewBadges(Guid clientID)
        {
            return Response<IEnumerable<ReviewBadgeTemplateDTO>>.Wrap(() =>
            {
                return RepoCache.Get<ReviewBadgeTemplate>()
                    .GetClientReviewBadges(clientID).Select(x => x.ToDto());
            });
        }
    }
}
