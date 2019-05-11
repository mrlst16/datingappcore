using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
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
                UsersRepoHelper.SetPhotos(request);
                return true;
            });
        }
    }
}
