using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;

        public UserService(
            IUserLoader loader
            )
        {
            _loader = loader;
        }

        public async Task AddUser(User user)
            => await _loader.AddUser(user);

        public async Task<User> GetUser(Guid id)
            => await _loader.GetUser(id);

        public Task<(bool, User)> SetUserPhotos(SetPhotosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, User)> SetUserProperties(SetPropertiesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, UserSettings)> SetUserSettings(UserSettings request)
        {
            throw new NotImplementedException();
        }
    }
}