using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetPhotosService : ISetPhotosService
    {
        public async Task<Response<bool>> Set(SetPhotosRequest request)
        {
            return Response<bool>.Wrap(() =>
            {
                var photos = request.Photos.Select(x =>
                {
                    x.UserID = request.UserID;
                    return x;
                });
                RepoCache.Get<Photo>()
                    .RemoveRange(photos)
                    .AddRange(request.Photos.Select(x =>
                    {
                        x.UserID = request.UserID;
                        return x;
                    }))
                    .Save();
                return true;
            });
        }
    }
}
