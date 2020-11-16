using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Intefaces
{
    public interface IUserContext
    {
        Task<User> GetUser(Guid id);
    }
}
