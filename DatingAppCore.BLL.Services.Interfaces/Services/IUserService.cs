using System;
using System.Threading.Tasks;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(Guid id);
        Task AddUser(User user);
        Task<(bool, UserSettings)> SetUserSettings(UserSettings request);
        Task<(bool, User)> SetUserProperties(SetPropertiesRequest request);
        Task<(bool, User)> SetUserPhotos(SetPhotosRequest request);
    }
}