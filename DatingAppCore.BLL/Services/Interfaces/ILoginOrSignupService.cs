using CommonCore.Responses;
using DatingAppCore.BLL.Responses;
using DatingAppCore.BLL.Signup.Requests;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ILoginOrSignupService
    {
        Response<LoginOrSignupResponse> LoginOrSignup(LoginOrSignupRequest request);
    }
}
