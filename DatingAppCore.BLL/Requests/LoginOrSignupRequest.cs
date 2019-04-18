using DatingAppCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.DTO.Members;

namespace DatingAppCore.BLL.Signup.Requests
{
    public class LoginOrSignupRequest
    {
        public UserDTO User { get; set; }
    }
}
