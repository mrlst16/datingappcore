using CommonCore.Responses;
using DatingAppCore.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetReviewService
    {
        Task<Response<GetReviewResponse>> GetReview(Guid userid);
    }
}
