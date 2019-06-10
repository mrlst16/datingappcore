using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface IGetPhotoStreamService
    {
        Task<Response<PhotoStreamResponse>> GetPhotoAsStream(GetPhotoStreamRequest request);
    }
}