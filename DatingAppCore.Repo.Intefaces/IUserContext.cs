using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Intefaces
{
    public interface IUserContext
    {
        Task<User> GetUser(Guid id);

        Task AddUser(User user);
    }
}
