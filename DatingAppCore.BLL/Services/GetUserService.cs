using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Services
{
    public class GetUserService : IGetUserService
    {
        public async Task<Response<UserDTO>> GetUser(GetUserRequest request)
        {
            return Response<UserDTO>.Wrap(() =>
            {
                var query = RepoCache
                    .GetQuery<User>()
                    .Where(x => x.ID == request.UserID);

                if (request.IncludeProfile)
                {
                    query = query.Include(x => x.Profile);
                }

                if (request.IncludeMessages)
                {
                    query = query.Include(x => x.Inbox);
                    query = query.Include(x => x.Sent);
                }

                if (request.IncludeSwipes)
                {
                    query = query.Include(x => x.SwipesReceived);
                    query = query.Include(x => x.SwipesSent);
                }

                if (request.IncludePhotos)
                {
                    query = query.Include(x => x.Photos);
                }

                if (request.IncludeReviews)
                {
                    query = query.Include(x => x.ReviewReceived);
                    query = query.Include(x => x.ReviewsSent);
                }

                if (request.IncludePermissions)
                {
                    query = query.Include(x => x.AsGrantee);
                    query = query.Include(x => x.AsGrantor);
                }

                var result = query
                    .FirstOrDefault()
                    ?.ToDto();

                result.Photos = result.Photos?.OrderBy(x => x.Rank).ToList() ?? null;

                return result;
            });
        }
    }
}