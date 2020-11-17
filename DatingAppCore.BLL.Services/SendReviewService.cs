using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Reviewing;
//using DatingAppCore.Repo.EF.Reviewing;

namespace DatingAppCore.BLL.Services
{
    public class SendReviewService : ISendReviewService
    {
        public async Task<Response<bool>> Send(SaveReviewRequest request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Review>().SendReview(request));
        }
    }
}
