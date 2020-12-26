using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public static class Errors
    {
        public static class Codes
        {
            public const string NoEmail = "0000001";
            public const string NoUsername = "0000002";
            public const string NoPassword = "0000003";
        }

        public static class Messages
        {
            public const string NoEmail = "No email was provider";
            public const string NoUsername = "No username was provider";
            public const string NoPassword = "No password was provider";
        }
    }
}
