using CommonCore.Interfaces.Repository;
using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Loaders
{
    public class UserLoader : IUserLoader
    {
        private readonly IEntityRepository<User> _repository;

        public UserLoader(
            IEntityRepository<User> repository
            )
        {
            _repository = repository;
        }

        public async Task AddUser(User user)
            => await _repository.Create(user);

        public async Task<User> GetUser(Guid id)
            => await _repository.Read(id);

        public async Task<(bool, User)> SetUserPhotos(SetPhotosRequest request)
        {
            var user = await _repository.Read(request.UserID);
            user.Photos = request.Photos;
            return await _repository.Update(user);
        }

        public async Task<(bool, User)> SetUserProperties(SetPropertiesRequest request)
        {
            var user = await _repository.Read(request.UserID);
            user.Profile = request.Properties;
            return await _repository.Update(user);
        }

        public async Task<(bool, User)> SetUserSettings(UserSettings request)
        {
            var user = await _repository.Read(request.UserID);
            user.Settings = request;
            return await _repository.Update(user);
        }
    }
}
