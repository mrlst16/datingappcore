using DatingAppCore.Entities.Members;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.Entities.Intefaces
{
    public interface IUserContext
    {
        Task<User> GetUser(Guid id);
    }
}
