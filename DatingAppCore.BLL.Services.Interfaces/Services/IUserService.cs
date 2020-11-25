using System;
using System.Threading.Tasks;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IGetUserService
    {
        Task<User> Process(Guid id);
    }
}