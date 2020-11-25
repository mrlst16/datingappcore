using CommonCore.Models.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ILoginOrSignupService
    {
        Task<LoginOrSignupResponse> Process(LoginOrSignupRequest request);
    }
}