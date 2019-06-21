using DatingAppCore.Dto.Members;

namespace DatingAppCore.Dto.Responses
{
    public class LoginOrSignupResponse
    {
        public bool Existed { get; set; }
        public UserDTO User { get; set; }
    }
}
