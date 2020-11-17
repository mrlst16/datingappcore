using DatingAppCore.Dto.Members;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.Dto.Requests
{
    public class LoginOrSignupRequest
    {
        public User User { get; set; }
    }
}
