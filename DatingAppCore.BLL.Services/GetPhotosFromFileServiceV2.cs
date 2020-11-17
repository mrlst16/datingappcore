using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
//using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class GetPhotosFromFileServiceV2 : IGetPhotoStreamService
    {
        public async Task<Response<PhotoStreamResponse>> GetPhotoAsStream(GetPhotoStreamRequest request)
        {
            return Response<PhotoStreamResponse>.Wrap(() =>
            {
                var path = Path.Combine(SavePhotoToFileService.USER_PHOTOS_FOLDER, request.UserID.ToString().ToLowerInvariant(), request.FileName);

                MemoryStream ms = new MemoryStream(File.ReadAllBytes(path));
                return new PhotoStreamResponse()
                {
                    ContentType = MimeType(path),
                    Stream = ms
                };
            });
        }

        private string MimeType(string filepath)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(filepath);
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null) mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
