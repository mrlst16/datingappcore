using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO
{
    public enum IDTypeEnum
    {
        Internal = 0,
        Facebook = 1,
        Twitter = 2,
        Gmail = 3
    }

    public enum SexEnum
    {
        Male = 0,
        Female = 1
    }

    public enum PhotoAccessLevelEnum
    {
        Public = 1,
        Private = 2,
        PerUser = 4
    }
    
    public enum MemberPermissionEnum
    {
        View = 1,
        Suggest = 2
    }

}