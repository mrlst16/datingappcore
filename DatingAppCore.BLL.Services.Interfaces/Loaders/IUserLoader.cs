using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Interfaces.Loaders
{
    public interface IUserLoader
    {
        Task<User> GetUser(Guid id);
        Task AddUser(User user);
        Task<(bool, User)> SetUserSettings(UserSettings request);
        Task<(bool, User)> SetUserProperties(SetPropertiesRequest request);
        Task<(bool, User)> SetUserPhotos(SetPhotosRequest request);
    }
}
