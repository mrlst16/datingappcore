using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Entities.Members;
using DatingAppCore.Repo.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class AddUserService : IAddUserService
    {
        private readonly IUserContext _userContext;

        public AddUserService(
            IUserContext userContext
            )
        {
            _userContext = userContext;
        }

        public async Task Process(User user)
        {
            await _userContext.AddUser(user);
        }
    }
}
