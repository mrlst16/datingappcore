using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface ILoginOrSignupService
    {
        Task<Response<LoginOrSignupResponse>> LoginOrSignup(LoginOrSignupRequest request);
    }
}