using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Repo.EF.Members;
using DatingAppCore.Repo.Members;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class SaveFormFilesToDatabaseService : ISaveFormFilesService
    {
        public virtual async Task<Response<bool>> Save(SaveFilesRequest request)
        {
            return Response<bool>.Wrap((response) =>
            {
                List<Task<Response<object>>> tasks = new List<Task<Response<object>>>();

                var repo = RepoCache.Get<Photo>();
                request.Files.Where(x => x.Length > 0)
                    .ToList()
                    .ForEach(formFile =>
                    {
                        tasks.Add(SavePhoto(formFile, request.UserID));
                    });

                Task.WaitAll(tasks.ToArray());

                var result = !tasks.Any(x => !x.Result.Sucess);

                if (!result)
                {
                    response
                        .IsUnSuccessful()
                        .WithExceptions(tasks.SelectMany(x => x.Result.Exceptions));
                }

                return result;
            });
        }

        protected virtual async Task<Response<object>> SavePhoto(IFormFile formFile, Guid userid)
        {
            return Response<object>.Wrap(() =>
            {
                var photoID = Guid.NewGuid();
                Photo photo = new Photo()
                {
                    ID = photoID,
                    Access = Dto.AccessLevelEnum.Private,
                    Rank = -1,
                    UserID = userid,
                    ContentType = formFile.ContentType,
                    Data = new PhotoData()
                    {
                        ID = Guid.NewGuid(),
                        Data = GetBtyes(formFile),
                        PhotoID = photoID
                    }
                };

                RepoCache.Get<Photo>()
                    .Add(photo)
                    .Save();

                return new { };
            });
        }

        protected byte[] GetBtyes(IFormFile formFile)
        {
            MemoryStream mstream = new MemoryStream();
            formFile.OpenReadStream().CopyTo(mstream);
            return mstream.ToArray();
        }
    }
}