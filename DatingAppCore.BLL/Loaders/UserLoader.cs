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
        private readonly ICrudRepository<User> _repository;

        public UserLoader(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _repository = crudRepositoryFactory.Get<User>();
        }

        public async Task AddUser(User user)
            => await _repository.Create(user);

        public async Task<User> GetUser(Guid id)
            => await _repository.First(x => x.ID == id);

        private async Task<(bool, User)> Update(User user)
            => await _repository.Update(user, x => x.ID == user.ID);

        public async Task<(bool, User)> SetUserPhotos(SetPhotosRequest request)
        {
            var user = await GetUser(request.UserID);
            user.Photos = request.Photos;
            return await Update(user);
        }

        public async Task<(bool, User)> SetUserProperties(SetPropertiesRequest request)
        {
            var user = await GetUser(request.UserID);
            user.Profile = request.Properties;
            return await Update(user);
        }

        public async Task<(bool, User)> SetUserSettings(UserSettings request)
        {
            var user = await GetUser(request.UserID);
            user.Settings = request;
            return await Update(user);
        }

        public async Task<User> GetUser(string username)
            => await _repository.First(x => x.UserName == username);
    }
}
