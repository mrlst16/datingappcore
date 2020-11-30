using CommonCore.Interfaces.Repository;
using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
