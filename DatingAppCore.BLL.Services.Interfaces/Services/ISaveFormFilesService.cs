using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISaveFormFilesService
    {
        Task<Response<bool>> Save(SaveFilesRequest request);
    }
}
