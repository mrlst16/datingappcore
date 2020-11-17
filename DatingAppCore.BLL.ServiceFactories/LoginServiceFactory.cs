using DatingAppCore.BLL.ServiceFactories.Interfaces;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.ServiceFactories
{
    public class LoginServiceFactory : ILoginServiceFactory<int>
    {
        public ILoginOrSignupService LoginOrSignupService(int selector)
        {
            return null;
            switch (selector)
            {
                case 1:
                    //return new LoginOrSignupService();
                default:
                    //return new LoginOrSignupService();
            }
        }
    }
}
