﻿using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class GetPhotosFromFileService : IGetPhotoStreamService
    {
        public async Task<Response<PhotoStreamResponse>> GetPhotoAsStream(GetPhotoStreamRequest request)
        {
            return Response<PhotoStreamResponse>.Wrap(() =>
            {
                Photo photo = RepoCache.GetQuery<Photo>()
                .Where(m => m.ID == request.PhotoID)
                .Include(x => x.Data)
                .FirstOrDefault();

                if (photo == null || photo.Data == null)
                    return null;

                var path = Path.Combine(SavePhotoToFileService.USER_PHOTOS_FOLDER, photo.UserID.ToString().ToLowerInvariant(), photo.FileName);

                MemoryStream ms = new MemoryStream(File.ReadAllBytes(path));
                return new PhotoStreamResponse()
                {
                    ContentType = photo.ContentType,
                    Stream = ms
                };
            });
        }
    }
}
