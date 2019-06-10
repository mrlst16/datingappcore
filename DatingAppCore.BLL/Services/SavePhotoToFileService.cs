using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
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
    public class SavePhotoToFileService : SaveFormFilesToDatabaseService
    {
        public const string USER_PHOTOS_FOLDER = "userphotos";

        public override async Task<Response<bool>> Save(SaveFilesRequest request)
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
                var userDirPath = Path.Combine(USER_PHOTOS_FOLDER, userid.ToString().ToLowerInvariant());
                if (!Directory.Exists(USER_PHOTOS_FOLDER)) Directory.CreateDirectory(USER_PHOTOS_FOLDER);
                if (!Directory.Exists(userDirPath)) Directory.CreateDirectory(userDirPath);

                var filePath = Path.Combine(userDirPath, formFile.FileName);
                File.WriteAllBytes(filePath, GetBtyes(formFile));

                var photoID = Guid.NewGuid();
                Photo photo = new Photo()
                {
                    ID = photoID,
                    Access = DTO.PhotoAccessLevelEnum.Private,
                    Rank = RepoCache.Get<Photo>().GetQuery().Count(x=> x.UserID == userid),
                    UserID = userid,
                    FileName = formFile.FileName,
                    ContentType = formFile.ContentType,
                    Data = new PhotoData()
                    {
                        ID = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                    }
                };

                RepoCache.Get<Photo>()
                    .Add(photo)
                    .Save();

                return new { };
            });
        }
    }
}