using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Responses
{
    public interface IResponse
    {
        bool Sucess { get; }
        List<Exception> Exceptions { get; }
        List<string> Messages { get; }
    }
}
