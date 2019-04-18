using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Reviewing;
using DatingAppCore.Repo.Reviewing;

namespace DatingAppCore.BLL.Services
{
    public class SendReviewService : ISendReviewService
    {
        public Response<bool> Send(ReviewDTO request)
        {
            return Response<bool>.Wrap(() =>
            {
                RepoCache.Get<Review>()
                    .Add(request.ToEntity())
                    .Save();
                return true;
            });
        }
    }
}
