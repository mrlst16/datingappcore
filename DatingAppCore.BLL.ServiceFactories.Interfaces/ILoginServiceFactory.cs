using DatingAppCore.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.ServiceFactories.Interfaces
{
    public interface ILoginServiceFactory<TSelector>
    {
        ILoginOrSignupService LoginOrSignupService(TSelector selector);
    }
}
