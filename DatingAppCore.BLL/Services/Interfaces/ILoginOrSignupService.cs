using CommonCore.Responses;
using DatingAppCore.BLL.Responses;
using DatingAppCore.BLL.Signup.Requests;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ILoginOrSignupService
    {
        Task<Response<LoginOrSignupResponse>> LoginOrSignup(LoginOrSignupRequest request);
    }
}
