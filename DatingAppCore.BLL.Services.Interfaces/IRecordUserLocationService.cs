using CommonCore.Responses;
using DatingAppCore.Entities.Members;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IRecordUserLocationService
    {
        Task<Response<bool>> Record(UserLocation userLocation);
    }
}