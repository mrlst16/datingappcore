using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Entities.Members;
using DatingAppCore.Repo.Intefaces;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class GetUserService : IUserService
    {
        private readonly IUserContext _userContext;

        public GetUserService(
            IUserContext userContext
            )
        {
            _userContext = userContext;
        }

        public async Task<User> Process(Guid id)
            => await _userContext.GetUser(id);
    }
}