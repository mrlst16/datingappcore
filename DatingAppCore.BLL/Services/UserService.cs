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

        public async Task<User> GetUser(string username)
            => await _loader.GetUser(username);

        public async Task<(bool, User)> SetUser(User user)
            => await _loader.SetUser(user);

        public async Task<(bool, User)> SetUserPhotos(SetPhotosRequest request)
            => await _loader.SetUserPhotos(request);

        public async Task<(bool, User)> SetUserProperties(SetPropertiesRequest request)
            => await _loader.SetUserProperties(request);

        public async Task<(bool, User)> SetUserSettings(UserSettings request)
            => await _loader.SetUserSettings(request);
    }
}