using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class SetPhotosUpdateOrderOnlyService : ISetPhotosService
    {
        public async Task<Response<bool>> Set(SetPhotosRequest request)
        {
            return Response<bool>.Wrap(() =>
            {
                List<Photo> updateThis = new List<Photo>();
                var queryAble = RepoCache.GetQuery<Photo>();
                for (int i = 0; i < request.Photos.Count; i++)
                {
                    var photo = request.Photos[i];
                    photo = queryAble.FirstOrDefault(x => x == photo);
                    if (photo == null) photo = request.Photos[i];

                    photo.UserID = request.UserID;
                    photo.Rank = i;
                    updateThis.Add(photo);
                }

                RepoCache
                    .Get<Photo>()
                    .RemoveRange(updateThis)
                    .AddRange(updateThis)
                    .Save();
                return true;
            });
        }
    }
}
