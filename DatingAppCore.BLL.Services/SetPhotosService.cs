using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetPhotosService : ISetPhotosService
    {
        public async Task<Response<bool>> Set(SetPhotosRequest request)
        {
            return Response<bool>.Wrap(() => SavePhotos( RepoCache.Get<Photo>(), request));
        }

        private static bool SavePhotos(Repository<Photo> repository, SetPhotosRequest request)
        {
            var photos = request.Photos.Select(x =>
            {
                x.UserID = request.UserID;
                return x.ToEntity();
            });
            repository
                .RemoveRange(photos)
                .AddRange(request.Photos.Select(x =>
                {
                    x.UserID = request.UserID;
                    return x.ToEntity();
                }))
                .Save();
            return true;
        }

    }
}
