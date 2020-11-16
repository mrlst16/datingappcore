using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.Dto.Responses;
using DatingAppCore.Repo.EF.Reviewing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.BLL.Services
{
    public class GetReviewService : IGetReviewService
    {
        public async Task<Response<GetReviewResponse>> GetReview(Guid userid)
        {
            return Response<GetReviewResponse>.Wrap(() =>
            {
                return RepoCache
                    .Get<Review>()
                    .GetReviewOfUser(userid);
            });
        }
    }
}
