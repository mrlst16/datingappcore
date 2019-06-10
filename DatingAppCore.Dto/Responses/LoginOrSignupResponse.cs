using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Responses
{
    public class LoginOrSignupResponse
    {
        public bool Existed { get; set; }
        public DatingAppCore.DTO.Members.UserDTO User { get; set; }
    }
}
