using DatingAppCore.Api.ServiceFactories.Interfaces;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Intefaces;

namespace DatingAppCore.Api.ServiceFactories
{
    public class UserServiceFactory : IUserServiceFactory<int>
    {
        private readonly IUserContext _userContext;

        public UserServiceFactory(
            IUserContext userContext
            )
        {
            _userContext = userContext;
        }

        public IAddUserService AddUserService(int selector)
        {
            switch (selector)
            {
                case 1:
                    return new AddUserService(_userContext);
                default:
                    return new AddUserService(_userContext);
            }
        }

        public IUserService GetUserService(int selector)
        {
            switch (selector)
            {
                case 1:
                    return new GetUserService(_userContext);
                default:
                    return new GetUserService(_userContext);
            }
        }


    }
}
