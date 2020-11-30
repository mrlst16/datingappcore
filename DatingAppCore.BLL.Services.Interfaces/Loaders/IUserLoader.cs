using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Interfaces.Loaders
{
    public interface IUserLoader
    {
        Task<User> GetUser(Guid id);

        Task AddUser(User user);

    }
}
