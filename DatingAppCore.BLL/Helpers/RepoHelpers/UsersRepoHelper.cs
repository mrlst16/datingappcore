using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Requests;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Helpers.RepoHelpers
{
    public static class UsersRepoHelper
    {
        public static List<User> GetUsersIn(List<Guid> ids)
        {
            try
            {
                return RepoCache.GetQuery<User>()
                    .Where(x => ids.Contains(x.ID))
                    .Include(x => x.Profile)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static UserDTO GetUser(GetUserRequest request)
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

            return query
                .FirstOrDefault()
                .ToDto();
        }

        public static bool SetPhotos(SetPhotosRequest request)
        {
            var photos = request.Photos.Select(x => x.ToEntity());
            RepoCache.Get<Photo>() 
                .RemoveRange(photos)
                .AddRange(request.Photos.Select(x => x.ToEntity()))
                .Save();
            return true;
        }
    }
}
