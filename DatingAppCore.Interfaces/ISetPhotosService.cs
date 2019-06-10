using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;

namespace DatingAppCore.Interfaces
{
    public interface ISetPhotosService
    {
        Task<Response<bool>> Set(SetPhotosRequest request);
    }
}
