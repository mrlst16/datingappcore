using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetPhotoStreamService
    {
        Task<Response<PhotoStreamResponse>> GetPhotoAsStream(GetPhotoStreamRequest request);
    }
}