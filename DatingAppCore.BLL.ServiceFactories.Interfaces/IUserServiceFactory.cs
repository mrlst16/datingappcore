using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.Api.ServiceFactories.Interfaces
{
    public interface IUserServiceFactory<TSelector>
    {
        IGetUserService GetUserService(TSelector selector);

        IAddUserService AddUserService(TSelector selector);
    }
}
