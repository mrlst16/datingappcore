using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Members;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.BLL.Services
{
    public class SetPhotosUpdateOrderOnlyService : ISetPhotosService
    {
        public async Task<Response<bool>> Set(SetPhotosRequest request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Photo>().SavePhotosOrer(request));
        }
    }
}