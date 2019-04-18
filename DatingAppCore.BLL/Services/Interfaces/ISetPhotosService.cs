using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISetPhotosService
    {
        Response<bool> Set(SetPhotosRequest request);
    }
}
