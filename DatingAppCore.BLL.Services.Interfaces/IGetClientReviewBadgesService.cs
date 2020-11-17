using CommonCore.Responses;
using DatingAppCore.Entities.Reviewing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetClientReviewBadgesService
    {
        Task<Response<IEnumerable<ReviewBadgeTemplate>>> GetClientReviewBadges(Guid clientID);
    }
}
