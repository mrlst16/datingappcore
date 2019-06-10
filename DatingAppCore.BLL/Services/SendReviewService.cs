using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.DTO.Reviewing;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Reviewing;

namespace DatingAppCore.BLL.Services
{
    public class SendReviewService : ISendReviewService
    {
        public async Task<Response<bool>> Send(ReviewDTO request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Review>().SendReview(request));
        }
    }
}
