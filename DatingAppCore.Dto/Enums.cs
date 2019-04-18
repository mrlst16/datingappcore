using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO
{
    public enum IDType
    {
        Internal = 0,
        Facebook = 1,
        Twitter = 2,
        Gmail = 3
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }

    public enum AccessLevel
    {
        Public = 1,
        Private = 2,
        PerUser = 3
    }
}