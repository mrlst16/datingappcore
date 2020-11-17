using DatingAppCore.Dto.Members;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.Dto.Responses
{
    public class LoginOrSignupResponse
    {
        public bool Existed { get; set; }
        public User User { get; set; }
    }
}
